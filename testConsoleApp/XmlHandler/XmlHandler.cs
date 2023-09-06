using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using UtilGeneral;

namespace XmlHandler
{
	/// <summary>
	/// Обработчик XML-файлов.
	/// </summary>
	public class XmlHandler
	{
		/// <summary>
		/// XML-документ.
		/// </summary>
		private XmlDocument _xDoc;

		/// <summary>
		/// Путь к документу.
		/// </summary>
		private string _url;

		/// <summary>
		/// Инициализация XML-документа.
		/// </summary>
		/// <param name="url">Путь к документу.</param>
		public XmlHandler(string url)
		{
			ValidationHelper.CheckStringIsNullOrEmpty(url);
			_url = url;

			_xDoc = new XmlDocument();
			_xDoc.Load(url);
		}

		/// <summary>
		/// Получения всех PK для выбранного тега.
		/// </summary>
		/// <param name="tag">Тег.</param>
		/// <returns>Список первичных ключей.</returns>
		public List<string> GetObjectsId(string tag)
		{
			ValidationHelper.CheckStringIsNullOrEmpty(tag);

			StringWriter buff = new StringWriter();
			XmlWriter data = new XmlTextWriter(buff);
			_xDoc.WriteTo(data);

			var xdoc = XDocument.Parse(buff.ToString());

			var result = new List<string>();

			var uid = Object_Dictionary.Tag_id[tag];

			result.AddRange(
				xdoc.Descendants(tag)
					.Descendants(uid)
					.Select(item => (string)item)
					.ToList()
				);

			return result;
		}

		/// <summary>
		/// Получение XML-документа по выбранному тегу и ключу.
		/// </summary>
		/// <param name="id">Ключ.</param>
		/// <param name="objectTag">Тег.</param>
		/// <returns>XML-документа.</returns>
		public XElement GetObjectXml(string id, string objectTag)
		{
			ValidationHelper.CheckStringIsNullOrEmpty(id);
			ValidationHelper.CheckStringIsNullOrEmpty(objectTag);

			StringWriter buff = new StringWriter();
			XmlWriter data = new XmlTextWriter(buff);
			_xDoc.WriteTo(data);

			var xdoc = XDocument.Parse(buff.ToString());

			var uid = Object_Dictionary.Tag_id[objectTag];

			var xmlElement =
				xdoc.Descendants(uid)
					.Where(item => item?.Value == id)
					.First();

			return addParentXml(xmlElement, objectTag);
		}

		/// <summary>
		/// Получение родительского тега.
		/// </summary>
		/// <param name="xElement">Текущий элемент.</param>
		/// <param name="objectName">Искомый тег.</param>
		/// <returns></returns>
		private XElement addParentXml(XElement xElement, string objectName)
		{

			if (xElement.Parent != null && xElement.Name != objectName)
			{
				return addParentXml(xElement.Parent, objectName);
			}

			return xElement;
		}
	}
}

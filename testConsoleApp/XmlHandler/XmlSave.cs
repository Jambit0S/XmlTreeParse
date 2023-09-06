using System.Configuration;
using System.Xml.Linq;

namespace XmlHandler
{
	public static class XmlSave
	{
		/// <summary>
		/// Сохранение XML-документа
		/// </summary>
		/// <param name="element">Документ.</param>
		public static void Save(XElement element)
		{
			var dir = ConfigurationManager.AppSettings["xmlojbectdirectory"];
			element.Save(dir);
		}
	}
}

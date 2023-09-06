using System;
using System.Xml.Linq;

namespace XmlHandler
{
	public static class XmlSave
	{
		/// <summary>
		/// Сохранение XML-документа
		/// </summary>
		/// <param name="element">Документ.</param>
		public static void Save(XElement element, string dir)
		{
			if (!string.IsNullOrEmpty(dir))
			{
				element.Save(dir);
			}
			else
			{
				throw new ArgumentException("Некорректный путь к новому объекту");
			}
		}
	}
}

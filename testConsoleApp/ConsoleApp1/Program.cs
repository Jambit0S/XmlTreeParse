using System;
using System.Configuration;
using XmlHandler;

namespace ConsoleApp1
{
	internal class Program
	{
		/// <summary>
		/// Тест работы библиотеки.
		/// </summary>
		static void Main(string[] args)
		{
			//Получение XML-документа.
			//Путь к документу хранится в конфигурации.
			var res = new XmlHandler.XmlHandler(ConfigurationManager.AppSettings["xmldata"]);

			//Получение PK для объектов с именем land_record.
			res.GetObjectsId("land_record").ForEach(item => Console.WriteLine(item));

			//Получение всего объекта land_record по его PK.
			var xmlObj = res.GetObjectXml("24:21:1003001:1", "land_record");

			//Сохранение объекта.
			XmlSave.Save(xmlObj);

			Console.ReadLine();
		}

	}
}

using System.Collections.Generic;

namespace XmlHandler
{
	/// <summary>
	/// Константы для поиска элементов в XML-документе.
	/// </summary>
	public static class Object_Dictionary
	{
		/// <summary>
		/// Справочник тег-ключ.
		/// </summary>
		public static Dictionary<string, string> Tag_id = new Dictionary<string, string>
		{
			{ "build_record", "cad_number" },
			{ "construction_record", "cad_number" },
			{ "land_record", "cad_number" },
			{ "municipal_boundaries", "reg_numb_border" },
			{ "spatial_data", "sk_id" },
			{ "zones_and_territories_record", "reg_numb_border" }
		};
	}
}

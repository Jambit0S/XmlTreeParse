using System;

namespace UtilGeneral
{
	/// <summary>
	/// Валидация.
	/// </summary>
	public static class ValidationHelper
	{
		/// <summary>
		/// Проверка строки на заполненость.
		/// </summary>
		/// <param name="value">Проверяемое значение.</param>
		/// <param name="message">Текст ошибки.</param>
		/// <exception cref="NullReferenceException">Получена пустая строка.</exception>
		public static void CheckStringIsNullOrEmpty(string value, string message = "Ожидается заполненная строка")
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException(message, nameof(value));
			}
		}
	}
}

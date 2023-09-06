using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormApp
{
	/// <summary>
	/// Текст ошибок.
	/// </summary>
	public static class ErrorMessageText
	{
		public static string Warning { get; } = "Внимание!";
		public static string WrongNodeSelect { get; } = "Пожалуйста, выберите дочерний узел";
	}
}

using System;

namespace Task2
{
	class ConsoleLoader
    {
		private string[] _strings;

		public string[] LoadData()
		{
			string input = Console.ReadLine();
			_strings = input.Split(' ');
			return _strings;
		}
	}
}

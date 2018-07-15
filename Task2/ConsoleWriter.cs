using System;

namespace Task2
{
    class ConsoleWriter
    {
		private string[] _strings;

		public ConsoleWriter(string[] strings)
		{
			_strings = strings;
		}

		public void WriteData()
		{
			foreach (string str in _strings)
				Console.Write(str + ' ');
			Console.Write('\n');
		}
    }
}

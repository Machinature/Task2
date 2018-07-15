using System.IO;

namespace Task2
{
	class FileLoader
	{
		private StreamReader streamReader;
		private string[] _strings;

		public FileLoader(string filename)
		{
			streamReader = new StreamReader(new FileStream(filename, FileMode.Open));
		}

		public string[] LoadData()
		{
			string input = streamReader.ReadLine();
			_strings = input.Split(' ');

			streamReader.Dispose();

			return _strings;
		}
	}
}
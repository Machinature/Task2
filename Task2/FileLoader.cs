using System.IO;

namespace Task2
{
	class FileLoader
	{
		private StreamReader streamReader;
		private string[] _strings;

		public FileLoader(string filename)
		{
			streamReader = new StreamReader(new FileStream(filename, FileMode.OpenOrCreate));
			string checkString = streamReader.ReadLine();
			if (checkString == null)
				SetDefaultDataToFile();
		}

		public string[] LoadData()
		{
			streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
			string input = streamReader.ReadToEnd();
			_strings = input.Split(' ');

			streamReader.Dispose();

			return _strings;
		}

		private void SetDefaultDataToFile()
		{
			string defaultString = "abaa bbb ccbacd";
			StreamWriter streamWriter = new StreamWriter(streamReader.BaseStream);
			streamWriter.WriteLine(defaultString);
			streamWriter.Flush();
		}
	}
}
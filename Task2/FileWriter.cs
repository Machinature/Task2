using System.IO;

namespace Task2
{
    class FileWriter
    {
		private StreamWriter streamWriter;
		private string[] _strings;

		public FileWriter(string filename, string[] strings)
		{
			streamWriter = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate));
			_strings = strings;
		}

		public void WriteData()
		{
			foreach (string str in _strings)
				streamWriter.Write(str + ' ');
			streamWriter.Write('\n');

			streamWriter.Dispose();
		}
    }
}

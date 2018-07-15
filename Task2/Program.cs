using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
			ConsoleLoader loader = new ConsoleLoader();
			string[] strings = loader.LoadData();

			Archiver archiver = new Archiver(strings);
			strings = archiver.ArchiveArray();

			ConsoleWriter writer = new ConsoleWriter(strings);
			writer.WriteData();

			int n = 1;
			Console.WriteLine(Convert.ToChar(n));

			Console.ReadKey();
        }
    }
}

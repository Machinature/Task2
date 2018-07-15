using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
			FileLoader loader = new FileLoader("input.txt");
			string[] strings = loader.LoadData();

			Archiver archiver = new Archiver(strings);
			strings = archiver.ArchiveArray();

			FileWriter writer = new FileWriter("result.txt", strings);
			writer.WriteData();

			Console.ReadKey();
        }
    }
}

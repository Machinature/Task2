using System;
using System.Linq;
using System.Collections.Generic;

namespace Task2
{
	public class Archiver
	{
		private string[] _strings;

		public Archiver(string[] strings) => _strings = strings;

		public string[] ArchiveArray()
		{
			return _strings.Select((str, indexOfString) => Archive(str, indexOfString)).ToArray();
		}

		private string Archive(string str, int indexOfString)
		{
			IEnumerable<SpecifiedLetter> specifiedString = str.Select((char letter, int index) => new SpecifiedLetter(letter, index, indexOfString));
			specifiedString = specifiedString.Select((sLetter) => IsNextSameCheck(sLetter));
			specifiedString = specifiedString.Select((sLetter) => IsLastUneccessaryCheck(sLetter));
			IEnumerable<SpecifiedLetter> uneccessaryLetters = specifiedString.Where(sLetter => sLetter.IsNextSame);
			specifiedString = CountUneccessaryLettersAndInsert(specifiedString, uneccessaryLetters);
			specifiedString = specifiedString.Where(sLetter => sLetter.IsNextSame == false);
			str = new string(specifiedString.Select(sLetter => sLetter.Letter).ToArray());
			return str;
		}

		private IEnumerable<SpecifiedLetter> CountUneccessaryLettersAndInsert(IEnumerable<SpecifiedLetter> specifiedString, IEnumerable<SpecifiedLetter> uneccessaryLetters)
		{
			int insertedNumbers = 0;
			for (int i = 0; i < uneccessaryLetters.Count(); i++)
			{
				int pos = uneccessaryLetters.ElementAt(i).Index + insertedNumbers;
				int number = 2; // minumum
				while (uneccessaryLetters.ElementAt(i).IsLastUneccessary == false && i < uneccessaryLetters.Count())
				{
					number++; // extra
					i++;
				}
				specifiedString = Insert(specifiedString, pos, number);
				insertedNumbers++;
			}
			return specifiedString;
		}

		private IEnumerable<SpecifiedLetter> Insert(IEnumerable<SpecifiedLetter> sLetters, int position, int number)
		{
			var leftPart = sLetters.Take(position);
			var rightPart = sLetters.Skip(position);
			rightPart = rightPart.Select(sLetter =>
			{
				sLetter.Index++;
				return sLetter;
			});
			rightPart = rightPart.Prepend(new SpecifiedLetter(Convert.ToChar(number), position, rightPart.Last().IndexOfString));
			sLetters = leftPart.Concat(rightPart);
			return sLetters;
		}

		private SpecifiedLetter IsNextSameCheck(SpecifiedLetter sLetter)
		{
			if (sLetter.Index != _strings.ElementAt(sLetter.IndexOfString).Count() - 1)
				if (sLetter.Letter == _strings.ElementAt(sLetter.IndexOfString).ElementAt(sLetter.Index + 1)) //only LINQ!!
					sLetter.IsNextSame = true;
			return sLetter;
		}

		private SpecifiedLetter IsLastUneccessaryCheck(SpecifiedLetter sLetter)
		{
			if (sLetter.Index != _strings.ElementAt(sLetter.IndexOfString).Count() - 1)
			{
				if (sLetter.Index == _strings.ElementAt(sLetter.IndexOfString).Count() - 2) //That block is equivalent to "sLetter.IsNextSame == true && sLetter.Next.IsNextSame == false" but I have no Next field
				{
					if (sLetter.IsNextSame == true)
					{
						sLetter.IsLastUneccessary = true;
					}
				}
				else
				{
					if (sLetter.IsNextSame == true &&
						_strings.ElementAt(sLetter.IndexOfString).ElementAt(sLetter.Index + 1) !=
						_strings.ElementAt(sLetter.IndexOfString).ElementAt(sLetter.Index + 2)) //only LINQ!!
					{
						sLetter.IsLastUneccessary = true;
					}
				}
			}
			return sLetter;
		}
	}
}

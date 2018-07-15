namespace Task2
{
    public class SpecifiedLetter
    {
        public char Letter;
        public int Index;
        public int IndexOfString;
        public bool IsNextSame;
        public bool IsLastUneccessary;

        public SpecifiedLetter(char letter, int index, int indexOfString)
        {
            Letter = letter;
            Index = index;
            IndexOfString = indexOfString;
            IsNextSame = false;
            IsLastUneccessary = false;
        }
    }
}

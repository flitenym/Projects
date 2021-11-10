namespace Brail
{
    public class BrailLetter
    {
        public BrailLetter(int[,] letter)
        {
            Letter = letter;
        }
        public int[,] Letter { get; set; } = new int[2, 3];
    }
}
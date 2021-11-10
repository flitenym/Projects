using System.Collections.Generic;

namespace Brail
{
    public static class BrailTranslater
    {
        private const int ColumnCount = 2;
        private const int RowCount = 3;
        private static Dictionary<char, BrailLetter> BrailDictionary = new Dictionary<char, BrailLetter>()
        {
            { 'А', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 0, 0, 0 } }) },
            { 'Б', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 0, 0, 0 } }) },
            { 'В', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 0 },{ 1, 1, 1 } }) },
            { 'Г', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 1, 1, 0 } }) },
            { 'Д', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 1, 1, 0 } }) },
            { 'Е', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 0, 1, 0 } }) },
            { 'Ё', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 0, 0, 1 } }) },
            { 'Ж', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 0 },{ 1, 1, 0 } }) },
            { 'З', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 0, 1, 1 } }) },
            { 'И', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 0 },{ 1, 0, 0 } }) },
            { 'Й', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 1, 0, 1 } }) },
            { 'К', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 0, 0, 0 } }) },
            { 'Л', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 0, 0, 0 } }) },
            { 'М', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 1, 0, 0 } }) },
            { 'Н', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 1, 1, 0 } }) },
            { 'О', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 0, 1, 0 } }) },
            { 'П', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 1, 0, 0 } }) },
            { 'Р', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 0, 1, 0 } }) },
            { 'С', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 1 },{ 1, 0, 0 } }) },
            { 'Т', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 1 },{ 1, 1, 0 } }) },
            { 'У', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 0, 0, 1 } }) },
            { 'Ф', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 1, 0, 0 } }) },
            { 'Х', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 0, 1, 0 } }) },
            { 'Ц', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 1, 0, 0 } }) },
            { 'Ч', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 1, 1, 0 } }) },
            { 'Ш', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 0 },{ 0, 1, 1 } }) },
            { 'Щ', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 0, 1 },{ 1, 0, 1 } }) },
            { 'Ъ', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 1 },{ 0, 1, 1 } }) },
            { 'Ы', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 1 },{ 1, 0, 1 } }) },
            { 'Ь', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 1 },{ 1, 1, 1 } }) },
            { 'Э', new BrailLetter(new int[ColumnCount, RowCount]{ { 0, 1, 0 },{ 1, 0, 1 } }) },
            { 'Ю', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 0, 1, 1 } }) },
            { 'Я', new BrailLetter(new int[ColumnCount, RowCount]{ { 1, 1, 0 },{ 1, 0, 1 } }) },
            { ' ', new BrailLetter(null) },
        };

        public static (List<BrailLetter> BrailText, List<string> ErrorInfo) TranslateText(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.Trim().ToUpper();
                List<BrailLetter> brailText = new List<BrailLetter>();
                List<string> errorInfo = new List<string>();
                foreach (char letter in text)
                {
                    if (BrailDictionary.ContainsKey(letter))
                    {
                        brailText.Add(BrailDictionary[letter]);
                    }
                    else
                    {
                        errorInfo.Add($"Нет данных для символа: {letter}");
                    }
                }
                return (brailText, errorInfo);
            }

            return default;
        }
    }
}
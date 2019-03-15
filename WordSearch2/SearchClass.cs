using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearch2
{
    public class SearchClass : IActurisSearch
    {
        public IEnumerable<string> Search(string grid, IEnumerable<string> wordsToCheck)
        {
            List<string> linesFromLeftToRight = grid.Split(new []{ '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> linesFromRightToLeft = new List<string>();
            linesFromRightToLeft.AddRange(linesFromLeftToRight.Select(ReverseString));

            List<string> linesFromTopToBottom = MakeLinesFromTopToBottom(linesFromLeftToRight);

            List<string> linesFromBottomToTop = new List<string>();
            linesFromBottomToTop.AddRange(linesFromTopToBottom.Select(ReverseString));

            List<string> linesAllDirections = linesFromLeftToRight.Concat(linesFromRightToLeft)
                .Concat(linesFromTopToBottom).Concat(linesFromBottomToTop).ToList();

            List<string> wordsFound = new List<string>();
            wordsFound.AddRange(wordsToCheck.Where(w => linesAllDirections.Any(l => l.Contains(w))));

            return wordsFound;
        }

        private static string ReverseString(string stringToReverse)
        {
            char[] charArray = stringToReverse.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private static List<string> MakeLinesFromTopToBottom(List<string> linesFromLeftToRight)
        {
            List<string> linesFromTopToBottom = new List<string>();
            for (int i = 0; i < linesFromLeftToRight[0].Length; i++)
            {
                StringBuilder stringBuilt = new StringBuilder();
                foreach (var word in linesFromLeftToRight)
                {
                    stringBuilt.Append(word[i]);
                }

                linesFromTopToBottom.Add(stringBuilt.ToString());
            }

            return linesFromTopToBottom;
        }
    }
}
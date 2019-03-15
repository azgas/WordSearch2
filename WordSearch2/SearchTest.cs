using System.Collections.Generic;
using NUnit.Framework;

namespace WordSearch2
{
    [TestFixture]
    public class SearchTest
    {
        private readonly SearchClass _search = new SearchClass();
        private readonly string _grid = "WORLD\n" + "HLWFM\n" + "PAPAD\n" + "EHLOC\n" + "FIREA\n";
        private List<string> _wordsToCheck;
        private List<string> _wordsFound;

        [Test]
        public void ShouldReturnNothingWhenWordsListToCheckIsEmpty()
        {
            _wordsToCheck = new List<string>();
            _wordsFound = new List<string>();

            Assert.AreEqual(_wordsFound, _search.Search(_grid, _wordsToCheck));
        }

        [Test]
        public void ShouldFindWordLeftToRight()
        {
            _wordsToCheck = new List<string> {"WORLD"};
            _wordsFound = new List<string> {"WORLD"};

            Assert.AreEqual(_wordsFound, _search.Search(_grid, _wordsToCheck));
        }

        [Test]
        public void ShouldFindWordRightToLeft()
        {
            _wordsToCheck = new List<string> { "APAP" };
            _wordsFound = new List<string> { "APAP" };

            Assert.AreEqual(_wordsFound, _search.Search(_grid, _wordsToCheck));
        }

        [Test]
        public void ShouldFindWordTopToBottom()
        {
            _wordsToCheck = new List<string> { "OLA" };
            _wordsFound = new List<string> { "OLA" };

            Assert.AreEqual(_wordsFound, _search.Search(_grid, _wordsToCheck));
        }

        [Test]
        public void ShouldFindManyWords()
        {
            _wordsToCheck = new List<string> {"FIRE", "APPLE", "WPL"};
            _wordsFound = new List<string> {"FIRE", "WPL"};
            Assert.AreEqual(_wordsFound, _search.Search(_grid, _wordsToCheck));
        }
    }
}
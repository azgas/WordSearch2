using System.Collections.Generic;

namespace WordSearch2
{
    interface IActurisSearch
    {
        IEnumerable<string> Search(string grid, IEnumerable<string> wordsToCheck);
    }
}

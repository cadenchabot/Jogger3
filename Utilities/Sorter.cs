using System;
using Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogger3
{
    /// <summary>
    /// Sorting class.
    /// </summary>
    class Sorter
    {
        /// <summary>
        /// Static method to sort high scores.
        /// </summary>
        /// <param name="scoresList"></param> The list of scores.
        /// <param name="namesList"></param> The list of names.
        public static void SortScores(LinkedList<int> scoresList, LinkedList<string> namesList)
        {
            for (int i = 0; i < scoresList.Size(); i++)
            {
                for (int j = 0; j < scoresList.Size() - 1; j++)
                {
                    if (scoresList.Get(j) < scoresList.Get(j+1))
                    {
                        int temp = scoresList.Get(j);
                        scoresList.Set(j, scoresList.Get(j + 1));
                        scoresList.Set(j + 1, temp);
                        string temp2 = namesList.Get(j);
                        namesList.Set(j, namesList.Get(j + 1));
                        namesList.Set(j + 1, temp2);
                    }
                }
            }
        }
    }
}

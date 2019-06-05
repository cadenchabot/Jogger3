using System;
using Collections;
namespace Jogger3
{
    /// <summary>
    /// Storage for high scores.
    /// </summary>
    class Storage
    {
        public static string currentName;
        public static int currentScore;
        public static string nameFileName   = "Names.txt";
        public static string pointsFileName = "Scores.txt";

        public static LinkedList<int>    scoresList = new LinkedList<int>();
        public static LinkedList<string> namesList  = new LinkedList<string>();
      
    }
}

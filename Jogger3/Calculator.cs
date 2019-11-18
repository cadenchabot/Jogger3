using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogger3
{
    /// <summary>
    /// Calculation class
    /// </summary>
    public class Calculator
    {
        
        private static Random random = new Random();

        /// <summary>
        /// Calculates a random speed between two integers
        /// </summary>
        /// <param name="min"></param> The minimum speed
        /// <param name="max"></param> The maximum speed
        /// <returns></returns> The calculated random speed
        public static int RandomSpeed(int min, int max)
        {
           return random.Next(min, max);
        }
    }
}

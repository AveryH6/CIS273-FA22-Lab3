using System;
using System.Collections.Generic;

namespace MeanMode
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static bool MeanMode(int[] array)
        {
            return computeMode(array) == computeAverage(array);
        }

        // TODO
        private static double computeAverage(int[] array)
        {
            int result = 0;

            for( int i = 0; i < array.Length; i++ )
            {
                result += array[i];
                
            }

            double avg = result / array.Length;

            return avg;
            
        }

        // TODO
        private static double? computeMode(int[] array)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (int a in array)
            {
                if (counts.ContainsKey(a))
                {
                    counts[a] = counts[a] + 1;
                }
                    
                else
                {
                    counts[a] = 1;
                }
                    
            }

            int result = int.MinValue;
            int max = int.MinValue;
            foreach (int key in counts.Keys)
            {
                if (counts[key] > max)
                {
                    max = counts[key];
                    result = key;
                }
            }

            return result;
        }
    }
}

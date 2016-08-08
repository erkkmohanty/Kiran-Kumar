using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class MaximumSubArray
    {

        public static int FindMaxSubArray(int[] array)
        {
            int current=0, max = 0;
            foreach(int i in array)
            {
                current += i;
                if (current < 0)
                    current = 0;
                if (current > max)
                    max = current;
            }
            return max;
        }

        public static int FindMaxSubArrayWithIndices(int[] array)
        {
            int startIndex = 0, endIndex = 0;
            int maxSum = 0;
            int currentSum = 0;

            for (int i = 0, j = 0; j < array.Length; j++)
            {
                currentSum += array[j];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startIndex = i;
                    endIndex = j;
                }
                else if (currentSum < 0)
                {
                    i = j + 1;
                    currentSum = 0;
                }
            }

            return maxSum;
        } 
    }
}

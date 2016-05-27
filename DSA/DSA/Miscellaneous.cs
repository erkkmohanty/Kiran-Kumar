using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class Miscellaneous
    {
        public static int CountMinimalWay(int[] targetArray)
        {
            int result = 0;
            if (targetArray.Length <= 0)
                return 0;
            while (true)
            {
                if (IsAllEven(targetArray))
                {
                    targetArray = targetArray.AsParallel().AsOrdered().Select(element => element / 2).ToArray();
                    ++result;
                }
                else
                {
                    for (int index = 0; index < targetArray.Length; index++)
                    {
                        if (targetArray[index] % 2 != 0)
                        {
                            targetArray[index] = targetArray[index] - 1;
                            ++result;
                        }
                    }
                }
                if (targetArray.Count(el => el == 0) == targetArray.Length)
                    break;
            }
            return result;
        }
        public static bool IsAllEven(int[] array)
        {
            int evenCount = 0;
            foreach (int element in array)
            {
                if (element % 2 == 0)
                    evenCount++;
            }
            return evenCount == array.Length;
        }
    }
}

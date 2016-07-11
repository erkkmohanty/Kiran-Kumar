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
            int evenCount = array.Count(element => element%2 == 0);
            return evenCount == array.Length;
        }

        public static void DoWrk( int input,out int output)
        {
            int local;
 
            Action doCalc = () =>
            {
                local = input * 2;   // this will work fine
                //valOut = valIn * i;  // this will be a compile time error
            };
 
            // you can use the out parameter to assign result of lambda 
            Func<int> doCalc2 = () => input * 2;
            output = doCalc2();   

        }
    }
}

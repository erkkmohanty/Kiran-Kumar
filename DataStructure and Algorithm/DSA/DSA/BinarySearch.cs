using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public class BinarySearch
    {
        public static int NormalBinarySearch(int[] array,int target)
        {
            int begin = 0;
            int end = array.Length-1;
            int result = -1;
            while(begin<=end)
            {
                int middle = (begin + end) / 2;

                if(array[middle]>target)
                {
                    end = middle - 1;
                }
                else if(array[middle]<target)
                {
                    begin = middle + 1;
                }
                else
                {
                    result = middle;
                    break;
                }
                
            }
            return result;
        }
        public static int RecursiveBinarySearch(int[] array,int target,int start,int end)
        {
            int result = -1;
            int middle = (start + end) / 2;
            if (end < start)
                return result;
            if(array[middle]>target)
            {
                result= RecursiveBinarySearch(array, target, start, middle - 1);
            }
            else if(array[middle]<target)
            {
                result= RecursiveBinarySearch(array, target, middle + 1, end);
            }
            else 
            {
                result= middle;
            }
            return result;
        }
    }

}

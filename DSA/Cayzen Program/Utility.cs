using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cayzen_Program
{
    static class Utility
    {
        /// <summary>
        /// Quick Sort
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lowerIndex"></param>
        /// <param name="higherIndex"></param>
        public static void QuickSort(string[] array, int lowerIndex, int higherIndex)
        {
            string pivotElement = array[lowerIndex + (higherIndex - lowerIndex) / 2];

            int tempLowerIndex = lowerIndex;
            int tempHigherIndex = higherIndex;
            while (tempLowerIndex <= tempHigherIndex)
            {
                while (array[tempLowerIndex].Length < pivotElement.Length)
                {
                    tempLowerIndex++;
                }
                while (array[tempHigherIndex].Length > pivotElement.Length)
                {
                    tempHigherIndex--;
                }
                if (tempLowerIndex <= tempHigherIndex)
                {
                    SwapText(tempLowerIndex, tempHigherIndex, array);
                    tempLowerIndex++;
                    tempHigherIndex--;
                }
            }
            if (lowerIndex < tempHigherIndex)
                QuickSort(array, lowerIndex, tempHigherIndex);
            if (tempLowerIndex < higherIndex)
                QuickSort(array, tempLowerIndex, higherIndex);

        }

        /// <summary>
        /// Bubble Sort
        /// </summary>
        /// <param name="array"></param>
        public static void BubbleSort(string[] array)
        {

            for (int iIndex = 0; iIndex < array.Length; iIndex++)
            {
                for (int jIndex = 1; jIndex < (array.Length - iIndex); jIndex++)
                {
                    if (array[jIndex - 1].Length > array[jIndex].Length)
                    {
                        SwapText(jIndex - 1, jIndex, array);
                    }
                }
            }
        }

        private static void SwapText(int lowerIndex, int higherIndex, string[] array)
        {
            string temp = array[lowerIndex];
            array[lowerIndex] = array[higherIndex];
            array[higherIndex] = temp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class BinaryHeap
    {
        static int children = 2;
        int heapSize;
        int[] heap;

        public BinaryHeap(int capacity)
        {
            heapSize = 0;
            heap = new int[capacity + 1];
            BinaryHeap.Fill<int>(heap, 0, capacity, -1);
        }

        public bool IsEmpty()
        {
            return heapSize == 0;
        }
        public bool IsFull()
        {
            return heapSize == heap.Length;
        }
        /** Clear heap */
        public void MakeEmpty()
        {
            heapSize = 0;
        }
        /** Function to  get index parent of i **/
        private int parent(int i)
        {
            return (i - 1) / children;
        }
        /** Function to get index of k th child of i **/
        private int kthChild(int i, int k)
        {
            return children * i + k;
        }

        /** Function to insert element */
        public void Insert(int x)
        {
            if (IsFull())
                throw new OutOfMemoryException("Array size exceeded");
            /** Percolate up **/
            heap[heapSize++] = x;
            heapifyUp(heapSize - 1);
        }

        /** Function to find least element **/
        public int FindMin()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Array is emty");
            return heap[0];
        }
        /** Function to delete min element **/
        public int deleteMin()
        {
            int keyItem = heap[0];
            delete(0);
            return keyItem;
        }

        /** Function to delete element at an index **/
        public int delete(int ind)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Array is emty");
            int keyItem = heap[ind];
            heap[ind] = heap[heapSize - 1];
            heapSize--;
            //heapifyDown(ind);
            return keyItem;
        }
        /** Function heapifyUp  **/
        private void heapifyUp(int childInd)
        {
            int tmp = heap[childInd];
            while (childInd > 0 && tmp < heap[parent(childInd)])
            {
                heap[childInd] = heap[parent(childInd)];
                childInd = parent(childInd);
            }
            heap[childInd] = tmp;
        }
        // Note: start is inclusive, end is exclusive (as is conventional
        // in computer science)
        public static void Fill<T>(T[] array, int start, int end, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (start < 0 || start >= end)
            {
                throw new ArgumentOutOfRangeException("fromIndex");
            }
            if (end >= array.Length)
            {
                throw new ArgumentOutOfRangeException("toIndex");
            }
            for (int i = start; i < end; i++)
            {
                array[i] = value;
            }
        }
    }
}

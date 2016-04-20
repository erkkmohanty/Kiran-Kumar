using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency
{
    class BasicParallel
    {
        internal static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source: values,
            localInit: () => 0,
            body: (item, state, localValue) => localValue + item,
            localFinally: localValue =>
            {
                lock (mutex)
                    result += localValue;
            });
            return result;
        }
        internal static int ParallelSumLinq(IEnumerable<int> values)
        {
            var d = values.AsParallel().Sum();
            return d;
        }
        internal static int ParallelSumLinq2(IEnumerable<int> values)
        {
            return values.AsParallel().Aggregate(
                seed: 0,
                func: (sum, item) => sum + item);
        }

        static void ProcessPartialArray(double[] array, int begin, int end)
        {
            array.AsParallel().Sum();
        }
        internal static void ProcessArray(double[] array)
        {
            Parallel.Invoke(
                () => ProcessPartialArray(array, 0, array.Length / 2),
                () => ProcessPartialArray(array, array.Length / 2, array.Length)
                );
        }
        static void DoAction20Times(Action action)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(actions);
        }

        static void DoAction20Times(Action action, CancellationToken cancelToken)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray();
            Parallel.Invoke(new ParallelOptions { CancellationToken = cancelToken }, action);
        }


        internal static IEnumerable<int> MultiplyBy2(IEnumerable<int> values)
        {
            return values.AsParallel().AsOrdered().Select(item => item * 2);
        }
    }
}

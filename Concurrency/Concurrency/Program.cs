using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicAsyncP();
            //BasicParallelP();
            BasicDataFlowP();
        }

        private static void BasicAsyncP()
        {
            object result = new object();
            BasicAsync.Delay<Object>(result, new TimeSpan(0, 1, 59));
            BasicAsync.DownloadStringWithRetries("technoarcade.com").Wait();
            BasicAsync.DownloadStringWithTimeout("technoarcade.com").Wait();
            CallMyMethodAsync().Wait();
            BasicAsync.DownloadAllAsync(new List<string> {  "http://www.thomas-bayer.com/sqlrest/CUSTOMER/"
                    ,"http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/","http://www.thomas-bayer.com/sqlrest/","http://www.example.com/customers/33245/orders"}).Wait();
            BasicAsync.FirstRespondingUrlAsync("http://www.example.com/customers/33245/orders"
                    , "http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/").Wait();
            BasicAsync.ProcessTask().Wait();
            BasicAsync.TestAsync().Wait();
            AsyncContext.Run(() => CallMyMethodAsync());
        }

        private static void BasicParallelP()
        {
            var data=BasicParallel.MultiplyBy2(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }).ToList();
            BasicParallel.ParallelSum(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            BasicParallel.ParallelSumLinq(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            BasicParallel.ProcessArray(new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        }

        private static void BasicDataFlowP()
        {
            BasicDataFlow.CreateMesh();
        }

        static async Task CallMyMethodAsync()
        {
            var progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
                {
                    Console.WriteLine(args);
                };
            await BasicAsync.MyMethodAsync(progress);
        }

        
    }
}

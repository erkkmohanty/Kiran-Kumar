using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Concurrency
{
    class BasicAsync
    {
        public static async Task<T> Delay<T>(T Result, TimeSpan delay)
        {
            await Task.Delay(delay).ConfigureAwait(false);
            return Result;
        }
        public static async Task<string> DownloadStringWithRetries(string uri)
        {
            using (var client = new HttpClient())
            {
                var nextDelay = TimeSpan.FromSeconds(1);
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        return await client.GetStringAsync(uri).ConfigureAwait(false);
                    }
                    catch
                    {

                    }
                    await Task.Delay(nextDelay);
                    nextDelay = nextDelay + nextDelay;
                }
                return await client.GetStringAsync(uri);
            }
        }

        public static async Task<string> DownloadStringWithTimeout(string uri)
        {
            using (var client = new HttpClient())
            {
                var downloadTask = client.GetStringAsync(uri);
                Task timeOutTask = Task.Delay(3000);

                var completedTask = await Task.WhenAny(downloadTask, timeOutTask);
                if (completedTask == timeOutTask)
                    return null;
                return await downloadTask;
            }
        }

        public static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            double percentComplete = 0;
            bool done = false;
            while (!done)
            {
                if (progress != null)
                    progress.Report(percentComplete);
                ++percentComplete;
                if (percentComplete > 100)
                    done = true;
            }
        }

        public static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
        {
            var httpClient = new HttpClient();
            var downloads = urls.Select(u => httpClient.GetStringAsync(u));

            Task<string>[] downloadTask = downloads.ToArray();
            Task t = Task.Delay(10);
            string[] htmlPages = new string[4];
            try
            {
                htmlPages = await Task.WhenAll(downloadTask).ConfigureAwait(false);
            }
            catch (Exception ex)
            {

            }
            return string.Concat(htmlPages);
        }

        public static async Task<int> FirstRespondingUrlAsync(string urlA, string urlB)
        {
            var httpClient = new HttpClient();

            Task<string> downloadTaskA = httpClient.GetStringAsync(urlA);
            Task<string> downloadTaskB = httpClient.GetStringAsync(urlB);

            Task<string> task = await Task.WhenAny(downloadTaskA, downloadTaskB);
            string data = await task;
            return data.Length;
        }
        static async Task<int> DelayAndReturnAsync(int val)
        {
            await Task.Delay(TimeSpan.FromSeconds(val));
            return val;
        }
        static async Task AwaitAndProcessAsync(Task<int> task)
        {
            var result = await task;
            Console.WriteLine("Process No. is::" + task.Result);
        }
        public static async Task ProcessTask()
        {
            Task<int> taskA = DelayAndReturnAsync(20);
            Task<int> taskB = DelayAndReturnAsync(50);
            Task<int> taskC = DelayAndReturnAsync(10);

            var tasks = new[] { taskA, taskB, taskC };
            var processingTasks = tasks.Select(async t =>
            {
                var result = await t.ConfigureAwait(continueOnCapturedContext: false);
                Console.WriteLine("Process No. is::" + t.Result);
            });

            await Task.WhenAll(processingTasks);
        }
        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            throw new InvalidOperationException("Test");
        }

        public static async Task TestAsync()
        {
            try
            {
                 await ThrowExceptionAsync();
            }
            catch (InvalidOperationException ex)
            {

                throw;
            }
        }
    }


    interface IMyAsyncInterface
    {
        Task<int> GetValueAsync();
    }
    class MySynchronousImplementation : IMyAsyncInterface
    {
        public Task<int> GetValueAsync()
        {
            return Task.FromResult(13);
        }
    }
}

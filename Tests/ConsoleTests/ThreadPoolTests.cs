using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleTests
{
    static class ThreadPoolTests
    {
        public static void Start()
        {
            var timer = Stopwatch.StartNew();
            //ThreadPool.SetMinThreads(1, 1);
            //ThreadPool.SetMaxThreads(1, 1);
            var message = Enumerable.Range(1, 1000)
                .Select(i => $"Message {i}")
            .ToArray();

            ThreadPool.GetAvailableThreads(out var avilable_worker_threads,out var avilable_completion_thread);
            ThreadPool.GetMinThreads(out var min_worker_threads, out var min_completion_thread);
            ThreadPool.GetMaxThreads(out var max_worker_threads, out var max_completion_thread);
            for (var i = 0; i < message.Length; i++)
            {
                var local_i = i;
                //new Thread(() => ProcessMessage(message[local_i])){IsBackground = true}.Start();
                ThreadPool.QueueUserWorkItem(o => ProcessMessage((string)o),message[i]);
            }
            timer.Stop();
            Console.Title = "Обработка заняла" + timer.Elapsed.TotalSeconds;
        }

        private static void ProcessMessage(string message)
        {
            Console.WriteLine($"Обработка сообщения {message}");
            //Thread.Sleep(5000);
            Console.WriteLine($"Обработка сообщения {message} закончена");
        }
    }
}

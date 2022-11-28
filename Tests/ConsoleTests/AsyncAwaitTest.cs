using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
    internal class AsyncAwaitTest
    { 
        private static void PrintThreadInfo(string Message = "")
        {
            var current_thread = Thread.CurrentThread;
            Console.WriteLine($"Thread id: {current_thread.ManagedThreadId} Task id: {Task.CurrentId}  {Message}");
        }

        public static async Task StartAsync()
        {
            Console.WriteLine("Запуск асинхронного метода выполняется синхронно!");
PrintThreadInfo("При входе в метод StartAsync"); 

            //var result_task = GetStringResultAsync();
            
            //var result = await result_task;

            var result = await GetStringResultRealAsync(); 
            
            
            Console.WriteLine($"Был получен результат {result}");
    PrintThreadInfo("При печати результата");

    var result2 = await GetStringResultRealAsync();


    Console.WriteLine($"Был получен результат #2 {result2}");
    PrintThreadInfo("При печати результата #2");

    for (int i = 0; i < 10; i++)
    {
        var result3 = await GetStringResultRealAsync();


        Console.WriteLine($"Был получен результат {i} {result3}");
        PrintThreadInfo("При печати результата ");
            }
        }

        private static async Task<string> GetStringResultAsync()
        {
            PrintThreadInfo("В псевдоасинхронном методе");
            return DateTime.Now.ToString();

              
        }

        private static Task<string> GetStringResultRealAsync()
        {
            PrintThreadInfo("В начале асинхронного метода");
            return Task.Run(() =>
            {
                PrintThreadInfo("Внутри асинхронного метода");
                return DateTime.Now.ToString();
            });

        }


        public static async Task ProcessDataTestAsync()
        {
            var messages = Enumerable.Range(1, 50).Select(i => $"Message {i}");//ToArray();

            var tasks = messages.Select(msg => Task.Run(() => LowSpeedPrinter(msg)));

            Console.WriteLine(">>>>>>>Подготовка к запуску обработки сообщений ...");
            var running_task = tasks.ToArray();
            Console.WriteLine(">>>>>>>Задачи созданы");
            await Task.WhenAll(running_task);

            Console.WriteLine(">>>>>>>Обработка всех сообщений завершена"); 
        }

        private static void LowSpeedPrinter(string msg)
        {
            Console.WriteLine($">>>>>>>[Thread id:{Thread.CurrentThread.ManagedThreadId}] Начинаю обработку {msg}...");
            Thread.Sleep(1000);
            Console.WriteLine($">>>>>>>[Thread id:{Thread.CurrentThread.ManagedThreadId}] Сообщение {msg} обработано");
        }

    }
}

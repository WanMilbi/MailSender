using System;
using System.Threading.Tasks;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = AsyncAwaitTest.StartAsync();
            var process_messages = AsyncAwaitTest.ProcessDataTestAsync(); 

Console.WriteLine("Тестовая задача запущена и мы ее ждем!");

Task.WaitAll(task,process_messages);

            Console.WriteLine("Главный поток работу закончил");
            Console.ReadLine();
        }

    }
}

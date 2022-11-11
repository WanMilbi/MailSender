using System;
using System.Threading;

namespace ConsoleTests
{
static class ThreadTests
    {
        public static void Start()
        {
            var main_thread = Thread.CurrentThread;
            var main_thread_id = main_thread.ManagedThreadId;
            main_thread.Name = "Главный поток";

            var timer_thread = new Thread(TimeMethod);
            timer_thread.Name = "Поток часов";
            timer_thread.IsBackground = true;
            timer_thread.Start();
            //var printer_thread = new Thread(PrintMessege)
            //{
            //     IsBackground = true,
            //     Name = "Parameter printer"
            //};
            //printer_thread.Start("Hello World!");

            var message = "Hello World";
            var count = 10;

            //new Thread(() => PrintMessage(message,count)){IsBackground = true}.Start();

            var print_task = new PrintMessageTask(message, count);
            print_task.Start();

            

            Console.WriteLine("Останавливаю время ...");
            timer_thread.Priority = ThreadPriority.BelowNormal;
            __TimerWork = false;
            if (!timer_thread.Join(100))
                timer_thread.Interrupt();

            timer_thread.Interrupt();
            Console.ReadLine();

        }

        private static void PrintMessege(object parameter)
        {
            PrintThreadInfo();
            var msg = (string)parameter;
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"id {thread_id}\t{msg}");
                Thread.Sleep(10);
            }
        }
        private static void PrintMessage(string Message, int Count)
        {
            PrintThreadInfo();

            var thread_id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"id {thread_id}\t{Message}");
                Thread.Sleep(10);
            }
        }

        private static  volatile bool __TimerWork = true;
        private static void TimeMethod()
        {
            PrintThreadInfo();
            while (__TimerWork)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss ffff");
                Thread.Sleep(100);
            }
        }

        private static void PrintThreadInfo()
        {
            var thread = Thread.CurrentThread;
            Console.WriteLine($"id: {thread.ManagedThreadId};name: {thread.Name};priority: {thread.Priority}");
        }
    }
    }


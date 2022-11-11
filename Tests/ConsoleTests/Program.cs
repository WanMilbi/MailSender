using System;
using System.Drawing;
using System.Threading;
using System.Threading.Channels;
using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using MailSender.lib.Service;
using Microsoft.VisualBasic;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Главный поток работу закончил");
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
        private static void PrintMessage(string Message,int Count)
        {
            PrintThreadInfo();
            
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"id {thread_id}\t{Message}");
                Thread.Sleep(10);
            }
        }
        private static void TimeMethod()
        {
            PrintThreadInfo();
            while (true)
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

    class PrintMessageTask
    {
        private readonly string _Message;
        private readonly int _Count;
        private Thread _Thread;

        public PrintMessageTask(string Message, int Count)
        {
            _Message = Message;
            _Count = Count;
            _Thread = new Thread(ThreadMethod){IsBackground = true};
        }

        public void Start()
        {
            if(_Thread?.IsAlive==false)
_Thread?.Start();
        }

        private void ThreadMethod()
        {
            var thread_id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < _Count; i++)
            {
                Console.WriteLine($"id {thread_id}\t{_Message}");
                Thread.Sleep(10);
            }
            _Thread = null;
        }
    }
}

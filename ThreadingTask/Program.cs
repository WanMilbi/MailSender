using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ThreadingTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new Thread(() =>
            //    {
            //        while (true)
            //        {
            //            Console.Title = DateTime.Now.ToString();
            //            Thread.Sleep(1000);
            //        }
            //    })
            //    { IsBackground = true }.Start();

            //new Task(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine(DateTime.Now);
            //        Thread.Sleep(1000);
            //    }
            //}).Start();

            //var task = new Task(() => { });
Parallel.Invoke(ParallelInvokeMethod,ParallelInvokeMethod, ParallelInvokeMethod, () => Console.WriteLine("Ещё один метод"));
            Console.ReadLine();
        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine($"ThrID:{Thread.CurrentThread.ManagedThreadId} - started");
            Thread.Sleep(250);
            Console.WriteLine($"ThrID:{Thread.CurrentThread.ManagedThreadId} - finished");
        }
        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine($"ThrID:{Thread.CurrentThread.ManagedThreadId} - started{msg}");
            Thread.Sleep(250);
            Console.WriteLine($"ThrID:{Thread.CurrentThread.ManagedThreadId} - finished{msg}");
        }
    }

    class MathTask
    {
        private readonly Thread _CalculationThread;
        private int _Result;
        private bool _IsCompleted;
        private bool IsCompleted => _IsCompleted;

        public int Result
        {
            get
            {
                if (!_IsCompleted)
                    _CalculationThread.Join();
                return _Result;
            }
        }

        public MathTask(Func<int> Calculation)
        {
            _CalculationThread = new Thread(() =>
            {
                _Result = Calculation();
                _IsCompleted = true;
            })
                { IsBackground = true };
        }
        public void Start() => _CalculationThread.Start();
    }
}

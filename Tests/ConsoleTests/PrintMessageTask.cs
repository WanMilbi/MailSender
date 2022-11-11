using System;
using System.Threading;

namespace ConsoleTests
{
    internal class PrintMessageTask
    {
    private readonly string _Message;
    private readonly int _Count;
    private Thread _Thread;

    public PrintMessageTask(string Message, int Count)
    {
        _Message = Message;
        _Count = Count;
        _Thread = new Thread(ThreadMethod) { IsBackground = true };
    }

    public void Start()
    {
        if (_Thread?.IsAlive == false)
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

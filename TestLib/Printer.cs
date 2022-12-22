using System;

namespace TestLib
{
    public class Printer
    {
        private readonly string _Prefix;

        public Printer(string Prefix)
        {
            _Prefix = Prefix;
        }

        public virtual void Print(string Message)
        {
            Console.WriteLine($"{_Prefix} {Message}");
        }

        internal class InternalPrinter : Printer
        {
            public int Value { get; set; }

            public InternalPrinter() : base("Internal")
            {

            }

            public virtual void Print(string Message)
            {
                Console.WriteLine("Private!" + Value);
                base.Print(Message);
            }
        }
    }
}

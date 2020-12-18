using System;
using Calculator.Operations;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1+3~(6/3)*2";
            Orchestrator orchestrator = new Orchestrator(s);
            Console.WriteLine(orchestrator.Calculate());
        }
    }
}

using System;
using Calculator.Operations;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "3+6-5*(2-4*(3-15+60/3))+12-2";
            Orchestrator orchestrator = new Orchestrator(s);
            Console.WriteLine(orchestrator.Calculate());
        }
    }
}

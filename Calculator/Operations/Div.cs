using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal class Div : Operation
    {
        public override int Priority => 2;
        public override char Sign => '/';
        public override int AdditionalPriority { get; set; }
        public override double Execute(List<double> operations)
        {
            if(operations[1] == 0)
            {
                throw new ArgumentException("Divide by zero");
            }
            return operations[0] / operations[1];
        }
    }
}

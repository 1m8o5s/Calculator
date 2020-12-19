using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal class Div : Operation
    {
        public override int Priority => 2;

        public override int AdditionalPriority { get; set; }

        public override double Execute(List<double> operations)
        {
            if(operations[1] == 0)
            {
                throw new DivideByZeroException();
            }
            return operations[0] / operations[1];
        }
    }
}

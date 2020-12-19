using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal class Sub : Operation
    {
        public override int Priority => 1;

        public override int AdditionalPriority { get; set; }

        public override double Execute(List<double> operations)
        {
            return operations[0] - operations[1];
        }
    }
}

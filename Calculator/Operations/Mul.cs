using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal sealed class Mul : Operation
    {
        public override int Priority => 2;

        public override int AdditionalPriority { get; set; }

        public override double Execute(List<double> operands)
        {
            return operands[0] * operands[1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal sealed class Pow : Operation
    {
        public override int Priority => 2;

        public override int AdditionalPriority { get; set; }

        public override double Execute(List<double> operands)
        {
            return Math.Pow(operands[0], operands[1]);
        }

    }
}

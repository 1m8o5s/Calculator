using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    class NotSupportedOperation : Operation
    {
        public override int Priority => default;

        public override int AdditionalPriority { get; set; }

        public override double Execute(List<double> operands)
        {
            return default;
        }
    }
}

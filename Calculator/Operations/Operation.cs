using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal abstract class Operation
    {
        public abstract int Priority { get; }
        public abstract int AdditionalPriority { get; set; }
        public abstract char Sign { get; }
        public abstract double Execute(List<double> operands);
    }
}

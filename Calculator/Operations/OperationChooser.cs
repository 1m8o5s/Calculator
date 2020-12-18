using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal sealed class OperationChooser
    {
        Dictionary<char, Func<Operation>> op;
        public static Operation NULL = new NotSupportedOperation();
        public OperationChooser()
        {
            op = new Dictionary<char, Func<Operation>>
            {
                {
                    '+', () => new Add()
                },
                {
                    '-', () => new Sub()
                },
                {
                    '/', () => new Div()
                },
                {
                    '*', () => new Mul()
                },
                {
                    '~', () => new Pow()
                }

            };
        }

        public Operation ChooseOperation(char operation)
        {
            if (SupportingOpperation(operation))
            {
                return op[operation].Invoke();
            }
            return NULL;
        }

        public bool SupportingOpperation(char operation)
        {
            return op.ContainsKey(operation);
        }
    }
}

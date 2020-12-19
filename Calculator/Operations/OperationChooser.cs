using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operations
{
    internal sealed class OperationChooser
    {
        private Dictionary<char, Func<Operation>> _operationsContainer;

        public static Operation NULL = new NotSupportedOperation();

        public OperationChooser()
        {
            _operationsContainer = new Dictionary<char, Func<Operation>>
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
                    '^', () => new Pow()
                }

            };
        }

        public Operation ChooseOperation(char operation)
        {
            if (SupportingOpperation(operation))
            {
                return _operationsContainer[operation].Invoke();
            }
            return NULL;
        }

        public bool SupportingOpperation(char operation)
        {
            return _operationsContainer.ContainsKey(operation);
        }
    }
}

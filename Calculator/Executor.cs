using Calculator.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Calculator
{
    internal sealed class Executor
    {
        private List<Operation> _operations;
        private List<double> _operands;
        private Operation _tempOperation;

        public Executor(List<Operation> operations, List<double> operands)
        {
            _operations = operations ?? default;
            _operands = operands ?? default;
            _tempOperation = OperationChooser.NULL;
        }

        public double Exec()
        {
            int op_count = _operations.Count;
            int max_priority;
            int max_priority_index;
            for (int i = 0; i < op_count; i++)
            {
                max_priority = 0;
                max_priority_index = 0;
                for (int j = 0; j < _operations.Count; j++)
                {
                    if (_operations[j].AdditionalPriority + _operations[j].Priority > max_priority)
                    {
                        max_priority = _operations[j].AdditionalPriority + _operations[j].Priority;
                        max_priority_index = j;
                    }
                }
                var result = _operations[max_priority_index].Execute(new List<double> { _operands[max_priority_index], _operands[max_priority_index + 1] });
                _operations.RemoveAt(max_priority_index);
                _operands.RemoveRange(max_priority_index, 2);
                _operands.Insert(max_priority_index, result);
            }
            return _operands[0];
        }
    }
}

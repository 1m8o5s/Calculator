using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Operations;
using Calculator.Bracket;
using System.Linq;

namespace Calculator
{
    class Parser
    {
        private List<Operation> _operations;

        private List<double> _operands;

        private OperationChooser _operationChooser;

        private ParsersValidator _validator;

        private string _expression;

        public Parser(string expression, OperationChooser operationChooser)
        {
            _expression = expression;
            _operations = new List<Operation>();
            _operands = new List<double>();
            _operationChooser = operationChooser;
            _validator = new ParsersValidator(_operationChooser);
        }

        public List<Operation> Operations
        {
            get=>new List<Operation>(_operations);
        }

        public List<double> Operands
        {
            get => new List<double>(_operands);
        }
        public void DisassembleOperations()
        {
            StringBuilder number = new StringBuilder();
            char last_s = default;
            int additional_priority = default;
            for (int i = 0; i < _expression.Length; i++)
            {
                if (char.IsDigit(_expression[i]))
                {
                    _validator.ValidateNumberAfterBrackets(last_s);
                    number.Append(_expression[i]);
                    if(i == _expression.Length - 1)
                    {
                        _operands.Add(double.Parse(number.ToString()));
                        number.Clear();
                    }
                }
                else
                {
                    if (number.Length != 0)
                    {
                        _operands.Add(double.Parse(number.ToString()));
                        number.Clear();
                    }
                    if (_expression[i] == Brackets.StartSign)
                    {
                        _validator.ValidateNumberBeforeBrackets(last_s);
                        additional_priority += Brackets.AdditionalPriority;
                    }
                    else if (_expression[i] == Brackets.StopSign)
                    {
                        _validator.ValidateOperatorInsideBrackets(last_s);
                        additional_priority -= Brackets.AdditionalPriority;
                    }
                    else if (_operationChooser.SupportingOpperation(_expression[i]))
                    {
                        _validator.ValidateOperatorNearBracetsOrOtherOperator(last_s);
                        _operations.Add(_operationChooser.ChooseOperation(_expression[i]));
                        _operations.Last().AdditionalPriority = additional_priority;
                    }
                    else
                    {
                        _validator.ValidateDontSupportSymbol(last_s);
                        continue;
                    }
                }
                last_s = _expression[i];
            }
        }
    }
}

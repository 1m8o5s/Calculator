using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Bracket;
using Calculator.Operations;

namespace Calculator
{
    class ParsersValidator
    {
        private OperationChooser _operationChooser { get; }
        public ParsersValidator(OperationChooser operationChooser)
        {
            _operationChooser = operationChooser;
        }
        public void ValidateNumberAfterBrackets(char last_symbol)
        {
            if (last_symbol == Brackets.StopSign)
            {
                throw new Exception("Program dont support writing numbers after brackets");
            }
        }
        public void ValidateNumberBeforeBrackets(char last_symbol)
        {
            if (char.IsDigit(last_symbol))
            {
                throw new Exception("Program dont support writing numbers before brackets");
            }
        }
        public void ValidateOperatorInsideBrackets(char last_symbol)
        {
            if (_operationChooser.SupportingOpperation(last_symbol))
            {
                throw new Exception("Program dont support writing operators after brackets");
            }
        }
        public void ValidateOperatorNearBracetsOrOtherOperator(char last_symbol)
        {
            if (_operationChooser.SupportingOpperation(last_symbol) || last_symbol == Brackets.StartSign)
            {
                throw new Exception("Program dont support operations without number operands");
            }
        }
        public void ValidateDontSupportSymbol(char last_symbol)
        {
            if (last_symbol != default)
            {
                throw new Exception("Program dont support this operation");
            }
        }

    }
}

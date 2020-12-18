using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Operations;

namespace Calculator
{
    class Orchestrator
    {
        private OperationChooser _operationChooser;
        private Parser _parser;
        private Executor _executor;
        
        public Orchestrator(string expression)
        {
            _operationChooser = new OperationChooser();
            _parser = new Parser(expression, _operationChooser);
            _parser.DisassembleOperations();
            _executor = new Executor(_parser.Operations, _parser.Operands);
        }
        public double Calculate()
        {
            return _executor.Exec();
        }
    }
}

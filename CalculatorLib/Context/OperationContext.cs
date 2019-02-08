using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;
using CalculatorLib.Operations;

namespace CalculatorLib.Context
{
    public class OperationContext : IOperationContext
    {
        private readonly Dictionary<OperationType, Type> _operations;

        public OperationContext(Initializer initializer)
        {
            _operations = initializer.InitFromAssembly();
        }

        public IEnumerable<string> GetOperationSingsByPriority(OperationPriority priority)
        {
            return _operations.Keys.Where(x => x.OperationPriority == priority).Select(x => x.OperationSign);
        }

        public Operations.Operation CreateOperation(string operationSign, IOperand leftOperand, IOperand rightOperand)
        {
            Type operationType = _operations.First(x=>x.Key.OperationSign == operationSign).Value;
            return (Operations.Operation) Activator.CreateInstance(operationType, leftOperand, rightOperand);
        }
    }
}

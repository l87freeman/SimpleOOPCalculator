using System.Collections.Generic;
using CalculatorLib.Operations;

namespace CalculatorLib.Interfaces
{
    public interface IOperationContext
    {
        IEnumerable<string> GetOperationSingsByPriority(OperationPriority priority);
        Operations.Operation CreateOperation(string operationSign, IOperand leftOperand, IOperand rightOperand);
    }
}

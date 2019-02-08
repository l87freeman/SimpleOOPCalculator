using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;

namespace CalculatorLib.Operations
{
    [Operation("*")]
    public class MultiplyOperation : Operation
    {
        public MultiplyOperation(IOperand leftOperand, IOperand rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override decimal GetValue()
        {
           return LeftOperand.GetValue() * RightOperand.GetValue();
        }
    }
}
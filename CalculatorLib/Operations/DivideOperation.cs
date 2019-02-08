using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;

namespace CalculatorLib.Operations
{
    [Operation("/")]
    public class DivideOperation : Operation
    {
        public DivideOperation(IOperand leftOperand, IOperand rightOperand) :
            base(leftOperand, rightOperand)
        {
        }

        public override decimal GetValue()
        {
            return LeftOperand.GetValue() / RightOperand.GetValue();
        }
    }
}
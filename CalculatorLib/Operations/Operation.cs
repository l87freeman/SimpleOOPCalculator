using CalculatorLib.Interfaces;

namespace CalculatorLib.Operations
{
    public abstract class Operation : IOperand
    {
        protected readonly IOperand LeftOperand;
        protected readonly IOperand RightOperand;

        protected Operation(IOperand leftOperand, IOperand rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }

        public abstract decimal GetValue();
    }
}
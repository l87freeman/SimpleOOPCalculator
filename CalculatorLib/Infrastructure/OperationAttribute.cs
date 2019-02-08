using System;

namespace CalculatorLib.Infrastructure
{
    public class OperationAttribute:Attribute
    {

        public OperationAttribute(string operationSign)
        {
            OperationSign = operationSign;
        }

        public string OperationSign { get; }
    }
}

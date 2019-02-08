namespace CalculatorLib.Operations
{
    public class OperationType
    {
        public OperationType(string operationSign, OperationPriority operationPriority)
        {
            OperationSign = operationSign;
            OperationPriority = operationPriority;
        }

        public string OperationSign { get; }
        public OperationPriority OperationPriority { get; }
    }
}

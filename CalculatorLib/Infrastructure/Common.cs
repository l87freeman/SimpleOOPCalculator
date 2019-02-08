using System.Collections.Generic;
using System.Linq;
using CalculatorLib.Operations;

namespace CalculatorLib.Infrastructure
{
    public static class Common
    {
        public static IEnumerable<OperationType> SupportedOperationTypes => new List<OperationType>
        {
            new OperationType("+", OperationPriority.Low),
            new OperationType("-", OperationPriority.Low),
            new OperationType("*", OperationPriority.High),
            new OperationType("/", OperationPriority.High)
        };

        public static string[] AllowedSigns => new string[] { "+", "-", "*", "/", "." };

        public static string[] SupportedOperation => SupportedOperationTypes.Select(x => x.OperationSign).ToArray();
    }
}

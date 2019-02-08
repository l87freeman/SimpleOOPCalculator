using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CalculatorLib.Operations;

namespace CalculatorLib.Infrastructure
{
    public class Initializer
    {
        public Dictionary<OperationType, Type> InitFromAssembly()
        {
            var assemblyOperations = GetType().Assembly.DefinedTypes
                .Where(t => typeof(Operation).IsAssignableFrom(t) && !t.IsAbstract &&
                            Attribute.IsDefined(t, typeof(OperationAttribute))).Select(x =>
                    new
                    {
                        OperationType = GetOperationType(x),
                        Type = x.AsType()
                    });
            return assemblyOperations.ToDictionary((type) => type.OperationType, (type) => type.Type);
        }

        private OperationType GetOperationType(TypeInfo type)
        {
            string operationSign = ((OperationAttribute)type.GetCustomAttribute(typeof(OperationAttribute)))
                .OperationSign;
            return Common.SupportedOperationTypes.First(x => x.OperationSign == operationSign);
        }
    }
}

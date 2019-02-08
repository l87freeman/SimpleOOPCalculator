using System;
using CalculatorLib;
using CalculatorLib.Context;
using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;

namespace CalculatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"input operation formula using figures, sign {String.Join("", Common.AllowedSigns)}");
            string userInput = Console.ReadLine();

            ExpressionParser parser = new ExpressionParser(new OperationContext(new Initializer()), new InputValidator());
            IOperand operation = parser.GetExpressions(userInput);

            decimal? result = operation?.GetValue();

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

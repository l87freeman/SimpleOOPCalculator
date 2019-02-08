using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorLib.Context;
using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;
using CalculatorLib.Operands;
using CalculatorLib.Operations;

namespace CalculatorLib
{
    public class ExpressionParser
    {
        private readonly IInputValidator _validator;
        public IOperationContext OperationContext { get; set; }

        public ExpressionParser() { }

        public ExpressionParser(IOperationContext context, IInputValidator validator)
        {
            _validator = validator;
            OperationContext = context;
        }

        public bool IsValid(string inputString)
        {
            return _validator.IsInputValid(inputString);
        }

        public IOperand GetExpressions(string inputString)
        {

            if (!IsValid(inputString))
            {
                throw new InvalidOperationException(_validator.ErrorMessage);
            }

            return CalculateExpression(inputString);
        }

        private IOperand CalculateExpression(string inputString)
        {
            IOperand output = null;

            int splitPosition = SignPosition(inputString,
                OperationContext.GetOperationSingsByPriority(OperationPriority.Low));
            if (splitPosition != -1)
            {
                output = CalculateOperands(inputString, splitPosition);
            }

            else if (splitPosition == -1)
            {
                splitPosition = SignPosition(inputString,
                    OperationContext.GetOperationSingsByPriority(OperationPriority.High));

                if (splitPosition != -1)
                {
                    output = CalculateOperands(inputString, splitPosition);
                }
            }

            if (IsDigit(inputString))
                output = new NumberOperand(inputString);

            return output;
        }

        IOperand CalculateOperands(string inputString, int splitPosition)
        {
            IOperand output = null;
            IOperand rightOperand = null;
            IOperand leftOperand = null;
            string divided = inputString.Substring(splitPosition + 1);
            string sign = inputString[splitPosition].ToString();

            rightOperand = CalculateExpression(divided);
            divided = inputString.Substring(0, splitPosition);
            leftOperand = CalculateExpression(divided);
            output = OperationContext.CreateOperation(sign, leftOperand, rightOperand);

            return output;
        }

        private bool IsDigit(string inputString)
        {
            var singsArray = Common.SupportedOperation;
            return SignPosition(inputString, singsArray) == -1 && inputString.Length > 0;
        }

        private int SignPosition(string inputString, IEnumerable<string> splitCharsString)
        {
            var splitChars = splitCharsString.SelectMany(x => x.ToCharArray()).ToArray();
            int position = inputString.LastIndexOfAny(splitChars);
            return position;
        }
    }
}
using System;
using System.Linq;
using CalculatorLib.Infrastructure;
using CalculatorLib.Interfaces;

namespace CalculatorLib
{
    public class InputValidator : IInputValidator
    {
        public string ErrorMessage { get; private set; }

        public bool IsInputValid(string userInput)
        {
            var validationResult = Validate((input) => !string.IsNullOrEmpty(input), userInput, "string is empty");
            validationResult = validationResult & IsValidSignSequence(userInput);
            validationResult = validationResult & Validate(IsLastSymbolNotASing, userInput, Common.AllowedSigns, "not allowed end symbol");

            return validationResult;
        }

        private bool IsValidSignSequence(string userInput)
        {
            bool output = true;
            int repeatSignCount = 0;

            foreach (char charInput in userInput)
            {
                string charString = charInput.ToString();
                output = output & Validate(IsValidChar, charString, $"not allowed symbol {charString}");
                output = output & Validate(charSting =>
                                       {
                                           if (!char.IsNumber(charSting, 0))
                                           {
                                               if (++repeatSignCount > 1)
                                               {
                                                   return false;
                                               }
                                           }
                                           else
                                           {
                                               repeatSignCount = 0;
                                           }

                                           return true;
                                       }, charString, $"repeating the {charString} symbol");

            }

            return output;
        }

        private bool Validate(Func<string, string[], bool> validationFunction, string input, string[] allowedSigns, string errorMessage)
        {
            if (!validationFunction(input, allowedSigns))
            {
                AddMessage(errorMessage);
                return false;
            }
            return true;
        }

        private bool Validate(Func<string, bool> validationFunction, string input, string errorMessage)
        {
            if (!validationFunction(input))
            {
                AddMessage(errorMessage);
                return false;
            }
            return true;
        }

        private bool IsValidChar(string inputCharString)
        {
            return Char.IsNumber(inputCharString, 0) || IsAllowedSymbol(inputCharString);
        }

        private bool IsLastSymbolNotASing(string userInput, string[] allowedSigns)
        {
            var lastElementIndex = userInput.Length - 1;
            if (lastElementIndex < 0)
            {
                return true;
            }
            return allowedSigns.All(x => x != userInput[lastElementIndex].ToString());
        }

        private bool IsAllowedSymbol(string inputSign)
        {
            return Common.AllowedSigns.Any(x => x == inputSign);
        }

        private void AddMessage(string errorMessage)
        {
            ErrorMessage += $"{errorMessage} {Environment.NewLine}";
        }
    }
}
using System;
using System.Globalization;
using CalculatorLib.Interfaces;

namespace CalculatorLib.Operands
{
    class NumberOperand : IOperand
    {
        private readonly decimal _value;

        public NumberOperand(string value)
        {
            _value = Decimal.Parse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
        }
        public decimal GetValue()
        {
            return _value;
        }
    }
}

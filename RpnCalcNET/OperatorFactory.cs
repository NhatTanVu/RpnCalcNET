using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpnCalcNET.Operators;

namespace RpnCalcNET
{
    public class OperatorFactory
    {
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string MULTIPLY = "*";
        public const string DIVIDE = "/";
        public const string PERCENTAGE = "%";
        public const string FACTORIAL = "!";
        public const string EXPONENTIAL = "^";
        public static readonly string[] OPERATORS = new string[] {
            PLUS, MINUS, MULTIPLY, DIVIDE, PERCENTAGE, FACTORIAL, EXPONENTIAL };

        public Operator CreateOperator(string strOperator)
        {
            switch (strOperator)
            {
                case PLUS:
                    return new Plus();
                case MINUS:
                    return new Minus();
                case MULTIPLY:
                    return new Multiply();
                case DIVIDE:
                    return new Divide();
                case PERCENTAGE:
                    return new Percentage();
                case FACTORIAL:
                    return new Factorial();
                case EXPONENTIAL:
                    return new Exponential();
                default:
                    throw new InvalidOperationException();
            };

            throw new InvalidOperationException();
        }
    }
}

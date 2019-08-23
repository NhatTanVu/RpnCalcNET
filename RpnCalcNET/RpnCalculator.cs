using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET
{
    public class RpnCalculator
    {
        public const char SEPARATOR = ' ';
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string MULTIPLY = "*";
        public const string DIVIDE = "/";
        public readonly string[] OPERATORS = new string[] { PLUS, MINUS, MULTIPLY, DIVIDE };

        public decimal Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException();

            string[] elements = expression.Split(SEPARATOR);
            Stack<decimal> numberStack = new Stack<decimal>();
            
            for(int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                if (!OPERATORS.Contains(element))
                {
                    numberStack.Push(decimal.Parse(element));
                }
                else
                {
                    decimal secondNumber = numberStack.Pop();
                    decimal firstNumber = numberStack.Pop();
                    decimal answer = 0;

                    switch (element) {
                        case PLUS:
                            answer = firstNumber + secondNumber;
                            break;
                        case MINUS:
                            answer = firstNumber - secondNumber;
                            break;
                        case MULTIPLY:
                            answer = firstNumber * secondNumber;
                            break;
                        case DIVIDE:
                            answer = Decimal.Truncate(firstNumber / secondNumber);
                            break;
                    }

                    numberStack.Push(answer);
                }
            }

            decimal result = numberStack.Pop();
            return result;
        }
    }
}

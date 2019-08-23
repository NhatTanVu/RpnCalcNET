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
        public const string PERCENTAGE = "%";
        public const string FACTORIAL = "!";
        public readonly string[] OPERATORS = new string[] {
            PLUS, MINUS, MULTIPLY, DIVIDE, PERCENTAGE, FACTORIAL };

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
                    decimal firstNumber = 0, answer = 0;

                    switch (element) {
                        case PLUS:
                            firstNumber = numberStack.Pop();
                            answer = firstNumber + secondNumber;
                            break;
                        case MINUS:
                            firstNumber = numberStack.Pop();
                            answer = firstNumber - secondNumber;
                            break;
                        case MULTIPLY:
                            firstNumber = numberStack.Pop();
                            answer = firstNumber * secondNumber;
                            break;
                        case DIVIDE:
                            firstNumber = numberStack.Pop();
                            answer = firstNumber / secondNumber;
                            break;
                        case PERCENTAGE:
                            answer = secondNumber / 100;
                            break;
                        case FACTORIAL:
                            var temp = 1;
                            if (!((secondNumber % 1) == 0))
                                throw new ArgumentOutOfRangeException();
                            for (int j = 1; j <= secondNumber; j++)
                                temp *= j;
                            answer = temp;
                            break;
                    }

                    numberStack.Push(answer);
                }
            }

            decimal result = numberStack.Pop();
            result = Decimal.Round(result, 3);
            return result;
        }
    }
}

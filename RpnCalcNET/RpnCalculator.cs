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
        
        public decimal Calculate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException();

            string[] elements = expression.Split(SEPARATOR);
            Stack<decimal> numberStack = new Stack<decimal>();
            
            for(int i = 0; i < elements.Length; i++)
            {
                string element = elements[i];
                if (!OperatorFactory.OPERATORS.Contains(element))
                {
                    numberStack.Push(decimal.Parse(element));
                }
                else
                {
                    decimal answer = new OperatorFactory().CreateOperator(element).Calculate(ref numberStack);
                    numberStack.Push(answer);
                }
            }

            decimal result = numberStack.Pop();
            result = Decimal.Round(result, 3);
            return result;
        }
    }
}

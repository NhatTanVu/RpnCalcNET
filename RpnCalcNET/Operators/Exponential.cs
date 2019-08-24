using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET.Operators
{
    public class Exponential: Operator
    {
        public override decimal Calculate(ref Stack<decimal> numberStack)
        {
            decimal secondNumber = numberStack.Pop();
            decimal firstNumber = numberStack.Pop();
            decimal answer = 1;
            for (int j = 1; j <= secondNumber; j++)
                answer *= firstNumber;
            return answer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET.Operators
{
    public class Factorial: Operator
    {
        public override decimal Calculate(ref Stack<decimal> numberStack)
        {
            decimal secondNumber = numberStack.Pop();
            if (!((secondNumber % 1) == 0))
                throw new ArgumentOutOfRangeException();
            decimal answer = 1;
            for (int j = 1; j <= secondNumber; j++)
                answer *= j;
            return answer;
        }
    }
}

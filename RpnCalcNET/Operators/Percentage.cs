using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET.Operators
{
    public class Percentage: Operator
    {
        public override decimal Calculate(ref Stack<decimal> numberStack)
        {
            decimal secondNumber = numberStack.Pop();
            return secondNumber / 100;
        }
    }
}

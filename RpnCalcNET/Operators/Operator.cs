using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET.Operators
{
    public abstract class Operator
    {
        public abstract decimal Calculate(ref Stack<decimal> numberStack);
    }
}

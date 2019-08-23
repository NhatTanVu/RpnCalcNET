using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnCalcNET
{
    [TestFixture]
    public class RpnCalculatorTests
    {
        [Test(Description = "Plus two numbers works")]
        public void PlusTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "1 2 +";
            Assert.That(calculator.Calculate(expression) == 3);
        }

        [Test(Description = "Minus two numbers works")]
        public void MinusTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "4 5 -";
            Assert.That(calculator.Calculate(expression) == -1);
        }

        [Test(Description = "Multiply two numbers works")]
        public void MultiplyTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2 3 *";
            Assert.That(calculator.Calculate(expression) == 6);
        }

        [Test(Description = "Divide two numbers works")]
        public void DivideTwoNumbersThenTruncated()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "4 3 /";
            Assert.That(calculator.Calculate(expression) == Decimal.Truncate(4/3));
        }

        [Test(Description = "Complex operation works")]
        public void ComplexOperationWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "15 7 1 1 + - / 3 * 2 1 1 + + -";
            Assert.That(calculator.Calculate(expression) == 5);
        }

        [Test(Description = "Null expression then throws exception")]
        public void NullExpressionThenThrowException()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = null;
            Assert.Throws(typeof(ArgumentNullException), delegate { calculator.Calculate(expression); });
        }

        [Test(Description = "Empty expression then throws exception")]
        public void EmptyExpressionThenThrowException()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "";
            Assert.Throws(typeof(ArgumentNullException), delegate { calculator.Calculate(expression); });
        }
    }
}

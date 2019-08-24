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
        [Test]
        public void PlusTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "1 2 +";
            Assert.That(calculator.Calculate(expression) == 3);
        }

        [Test]
        public void MinusTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "4 5 -";
            Assert.That(calculator.Calculate(expression) == -1);
        }

        [Test]
        public void MultiplyTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2 3 *";
            Assert.That(calculator.Calculate(expression) == 6);
        }

        [Test]
        public void DivideTwoNumbersWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "1 2 /";
            Assert.That(calculator.Calculate(expression) == (decimal)0.5);
        }

        [Test]
        public void ComplexExpressionWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "15 7 1 1 + - / 3 * 2 1 1 + + -";
            Assert.That(calculator.Calculate(expression) == 5);
        }

        [Test]
        public void NullExpressionThenThrowException()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = null;
            Assert.Throws(typeof(ArgumentNullException), delegate { calculator.Calculate(expression); });
        }

        [Test]
        public void EmptyExpressionThenThrowException()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "";
            Assert.Throws(typeof(ArgumentNullException), delegate { calculator.Calculate(expression); });
        }

        [Test]
        public void ReturnThreePrecisionPointsWithoutRoundUp()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "1 3 /";
            Assert.That(calculator.Calculate(expression) == (decimal)0.333);
        }

        [Test]
        public void ReturnThreePrecisionPointsWithRoundUp()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2.000 3 /";
            Assert.That(calculator.Calculate(expression) == (decimal)0.667);
        }

        [Test]
        public void ComplexExpressionReturnThreePrecisionPoints()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2 3 / 2.21 *";
            Assert.That(calculator.Calculate(expression) == (decimal)1.473);
        }

        [Test]
        public void PercentageOperatorWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "10 %";
            Assert.That(calculator.Calculate(expression) == (decimal)0.1);
        }

        [Test]
        public void ComplexExpressionAndPercentageOperatorWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "1 10 % +";
            Assert.That(calculator.Calculate(expression) == (decimal)1.1);
        }

        [Test]
        public void ComplexExpressionAndDecimalPercentageOperatorWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "3.76 25.5 % -";
            Assert.That(calculator.Calculate(expression) == (decimal)3.505);
        }

        [Test]
        public void InputHasFactorialOperator()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "4 !";
            Assert.That(calculator.Calculate(expression) == (decimal)24);
        }

        [Test]
        public void DecimalFactorialOperatorThenThrowException()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2.2 !";
            Assert.Throws(typeof(ArgumentOutOfRangeException), delegate { calculator.Calculate(expression); });
        }

        [Test]
        public void DecimalExponentialOperatorWorks()
        {
            RpnCalculator calculator = new RpnCalculator();
            string expression = "2.2 3 ^";
            Assert.That(calculator.Calculate(expression) == (decimal)10.648);
        }
    }
}

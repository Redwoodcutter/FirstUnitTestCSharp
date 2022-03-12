using First_Unit_Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_NUnit_Test
{
    [TestFixture]
    public class CalculatorNunitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new Calculator();
            //Act
            int result = calc.AddNumbers(10, 20);
            //Assert
            Assert.AreEqual(30, result);
        }
        [Test]
        public void IsOddNumber_ReturnTrue()
        {
            Calculator isOdd = new ();

            bool IsOddResult = isOdd.IsOddNumbers(3);

            Assert.IsTrue(IsOddResult);
            //Assert.That(IsOddResult, IsEqualTo(true));
        }
        [Test]
        [TestCase(4)]
        [TestCase(12)]
        [TestCase(70)]
        public void IsOddNumber_ReturnFalse(int a)
        {
            Calculator isNotOld = new Calculator();

            bool IsNotOldResult = isNotOld.IsOddNumbers(a);

            Assert.IsFalse(IsNotOldResult);
           //Assert.That(IsOddResult, IsEqualTo(false));

        }
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddNumber_ReturnTrue_Checker(int a)
        {
            Calculator calc = new();

            return calc.IsOddNumbers(a);
        }

    }
}

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
        private Calculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
         
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
          

            return calc.IsOddNumbers(a);
        }
        [Test]
        [TestCase(5.4, 1.6)]
        [TestCase(2.3,6.40)] 
        [TestCase(3.54, 1.60)] 
        public void AddNumbers_InputTwoDouble(double a, double b)
        {
            //Arrange
          
            //Act
            double result = calc.AddNumbersDouble(a,b);
            //Assert
            Assert.AreEqual(7.0, result,2);
        }
        [Test]
        public void OddRanger_MinMaxRangeOddNumber()
        {
            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10
            //Act
            List<int> result = calc.getOddRange(5,10);
            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual(expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));
            Assert.That(result, Is.Ordered);
        }

    }
}

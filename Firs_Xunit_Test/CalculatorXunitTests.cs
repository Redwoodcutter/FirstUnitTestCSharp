
using First_Unit_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_Xunit_Test
{
    public class CalculatorXunitTests
    {
       
    
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();
            //Act
            int result = calc.AddNumbers(10, 20);
            //Assert
            Assert.Equal(30, result);
        }
        [Fact]
        public void IsOddNumber_ReturnTrue()
        {
            Calculator isOdd = new ();

            bool IsOddResult = isOdd.IsOddNumbers(3);

            Assert.True(IsOddResult);
            //Assert.That(IsOddResult, IsEqualTo(true));
        }
        [Theory]
        [InlineData(4)]
        [InlineData(12)]
        [InlineData(70)]
        public void IsOddNumber_ReturnFalse(int a)
        {
            Calculator isNotOld = new Calculator();

            bool IsNotOldResult = isNotOld.IsOddNumbers(a);

            Assert.False(IsNotOldResult);
           //Assert.That(IsOddResult, IsEqualTo(false));

        }
        [Theory]
        [InlineData(10,  false)]
        [InlineData(11,  true)]
        public void IsOddNumber_ReturnTrue_Checker(int a, bool expectedResult)
        {
            Calculator calc = new();
            var result = calc.IsOddNumbers(a);
            Assert.Equal(expectedResult,result);
        }

        [Theory]
        [InlineData(5.4, 10.6)] //15.9
        [InlineData(5.43, 10.53)] // 15.96 -> 16.0
        [InlineData(5.49, 10.59)] // 16.08
        public void AddNumbers_InputTwoDouble(double a, double b)
        {
            //Arrange
            Calculator calc = new();
            //Act
            double result = calc.AddNumbersDouble(a, b);
            //Assert
            Assert.Equal(15.9, result, 0); //rounded not work like Nunit
        }
        [Fact]
        public void OddRanger_MinMaxRangeOddNumber()
        {
            Calculator calc = new();

            List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10
            //Act
            List<int> result = calc.getOddRange(5, 10);
            //Assert
            Assert.Equal(expectedOddRange,result);
            //Assert.AreEqual(expectedOddRange, result);
            //Assert.Contains(7, result);
            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3,result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(x=>x),result);
            //Assert.That(result, Is.Ordered);
        }

    }
}

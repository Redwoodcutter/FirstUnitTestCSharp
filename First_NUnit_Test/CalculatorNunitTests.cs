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

    }
}

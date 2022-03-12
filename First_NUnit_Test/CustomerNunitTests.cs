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
    public class CustomerNunitTests
    {
        [Test]
        public void FirstLastName_ReturnFullName()
        {
            //Arrange
            var customer = new Customer();
            //Act
            string fullName = customer.GreatingWithNames("Oguz", "Kumcular");
            //Assert
            Assert.AreEqual(fullName, "Hello, Oguz Kumcular");
            Assert.That(fullName, Is.EqualTo("Hello, Oguz Kumcular"));
            Assert.That(fullName, Does.Contain("oguz Kumcular").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("Kumcular"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));

        }
    }
}

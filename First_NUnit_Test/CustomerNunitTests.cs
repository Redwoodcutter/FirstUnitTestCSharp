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
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        public void FirstLastName_ReturnFullName()
        {
            //Arrange
            
            //Act
            customer.GreatingWithNames("Oguz", "Kumcular");
            Assert.Multiple(() =>
            {
                // Mulltiple Assert
                Assert.AreEqual(customer.GreetingMessage, "Hello, Oguz Kumcular");
                Assert.That(customer.GreetingMessage, Is.EqualTo("Hello, Oguz Kumcular"));
                Assert.That(customer.GreetingMessage, Does.Contain("oguz Kumcular").IgnoreCase);
                Assert.That(customer.GreetingMessage, Does.StartWith("Hello,"));
                Assert.That(customer.GreetingMessage, Does.EndWith("Kumcular"));
                Assert.That(customer.GreetingMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
            });

        }
        [Test]
        public void GreetingMessageReturnsNull()
        {
            //arrange
           
            //act
          
            //assert
            Assert.IsNull(customer.GreetingMessage);
        }

        [Test]
        public void DiscountDiscountRange()
        {
            int result = customer.Discount;
            Assert.That(result, Is.InRange(10, 25));
        }
        [Test]
        public void GreatingMessageWithoutLastName()
        {
            customer.GreatingWithNames("Oguz", "");

            Assert.IsNotNull(customer.GreetingMessage);

            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetingMessage));
        }
        [Test]
        public void GreatCheckerException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreatingWithNames("", "Kumcular"));
            Assert.AreEqual("Empty First Name", exceptionDetails.Message);
            Assert.That(() => customer.GreatingWithNames("", "Kumcular"), Throws.ArgumentException.With.Message.EqualTo("Empty First Name"));
        }
    }
}

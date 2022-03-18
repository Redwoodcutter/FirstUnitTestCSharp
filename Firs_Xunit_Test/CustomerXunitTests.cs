using First_Unit_Test;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_Xunit_Test
{
    public class CustomerXunitTests
    {
        private Customer customer;
       
        public  CustomerXunitTests()
        {
            customer = new Customer();
        }

        [Fact]
        public void FirstLastName_ReturnFullName()
        {
            //Arrange

            //Act
            customer.GreatingWithNames("Oguz", "Kumcular");
            
           Assert.Equal("Hello, Oguz Kumcular", customer.GreetingMessage);
           Assert.Contains("oguz Kumcular".ToLower(),customer.GreetingMessage.ToLower());
           Assert.StartsWith("Hello",customer.GreetingMessage);
           Assert.Matches( "Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetingMessage);
          

        }
        [Fact]
        public void GreetingMessageReturnsNull()
        {
            //arrange

            //act

            //assert
            Assert.Null(customer.GreetingMessage);
        }

        [Fact]
        public void DiscountDiscountRange()
        {
            int result = customer.Discount;
            Assert.InRange(result, 10, 25);
        }
        [Fact]
        public void GreatingMessageWithoutLastName()
        {
            customer.GreatingWithNames("Oguz", "");

            Assert.NotNull(customer.GreetingMessage);

            Assert.False(string.IsNullOrEmpty(customer.GreetingMessage));
        }
        [Fact]
        public void GreatCheckerException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreatingWithNames("", "Kumcular"));
            Assert.Equal("Empty First Name", exceptionDetails.Message);
            Assert.Throws<ArgumentException>(() => customer.GreatingWithNames("", "Kumcular"));
        }
        [Fact]
        public void CustomerType_CreateCustomer_BasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.IsType<BasicCustomer>(result);
        }
        [Fact]
        public void CustomerType_CreateCustomer_PlatinumCustomer()
        {
            customer.OrderTotal = 140;
            var result = customer.GetCustomerDetails();
            Assert.IsType<PlatinumCustomer>(result);
        }

    }
}

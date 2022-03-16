using First_Unit_Test;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_NUnit_Test
{
    [TextFixture]
    public class ProductNunitTests
    {
        [Test]
        public void GetProductPricePlatinumCustomer_20Discount()
        {
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true});

            Assert.That(result, Is.EqualTo(40));
        }
        [Test]
        public void MOQABUSE_GetProductPricePlatinumCustomer_20Discount() // NOT GOOD CHOSE
        {
            var customer = new Mock<ICustomer>();
            customer.SetupGet(x => x.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);

            Assert.That(result, Is.EqualTo(40));
        }

    }
}

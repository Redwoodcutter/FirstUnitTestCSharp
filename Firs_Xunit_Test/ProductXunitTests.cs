using First_Unit_Test;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_Xunit_Test
{
    public class ProductXunitTests
    {
        [Fact]
        public void GetProductPricePlatinumCustomer_20Discount()
        {
            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            Assert.Equal(40, result);
        }
        [Fact]
        public void MOQABUSE_GetProductPricePlatinumCustomer_20Discount() // NOT GOOD CHOSE
        {
            var customer = new Mock<ICustomer>();
            customer.SetupGet(x => x.IsPlatinum).Returns(true);

            Product product = new Product() { Price = 50 };

            var result = product.GetPrice(customer.Object);

            Assert.Equal(40, result);
        }

    }
}

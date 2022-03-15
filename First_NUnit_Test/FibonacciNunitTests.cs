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
    public class FibonacciNunitTests
    {
        [Test]
        public void FiboCheckOneInputSeries()
        {
            List<int> expectedRange = new() {0};
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.Range = 1;

            List<int> result = fibonacci.GetFiboSeries();
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

        public void FiboCheckMoreInputSeries()
        {
            List<int> expectedRange = new() { 0,1,1,2,3,5 };
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.Range = 6;

            List<int> result = fibonacci.GetFiboSeries();
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedRange));
        }

    }
}

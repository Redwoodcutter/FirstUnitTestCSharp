using First_Unit_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_Xunit_Test
{
  
    public class FibonacciXunitTests
    {
        [Fact]
        public void FiboCheckOneInputSeries()
        {
            List<int> expectedRange = new() { 0 };
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.Range = 1;

            List<int> result = fibonacci.GetFiboSeries();
            Assert.NotEmpty(result);
            Assert.Equal(expectedRange.OrderBy(x=>x), result);
            Assert.True(result.SequenceEqual(expectedRange));
        }
        [Fact]
        public void FiboCheckMoreInputSeries()
        {
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.Range = 6;

            List<int> result = fibonacci.GetFiboSeries();
            Assert.Contains(3,result);
            Assert.Equal(6,result.Count);
            Assert.DoesNotContain(4,result);
            Assert.Equal(expectedRange,result);
        }

    }
}

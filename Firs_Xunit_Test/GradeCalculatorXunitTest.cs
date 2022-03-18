using First_Unit_Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_Xunit_Test
{
    public class GradeCalculatorXunitTest
    {
        private GradeCalculator gradeCalculator;
       
        public GradeCalculatorXunitTest()
        {
            gradeCalculator = new GradeCalculator();
        }

        [Fact]
        public void GradeA_Attendees90()
        {
            gradeCalculator.Score = 95;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("A",result);
        }
        [Fact]
        public void GradeB_Attendees90()
        {
            gradeCalculator.Score = 85;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("B",result);
        }
        [Fact]
        public void GradeC_Attendees90()
        {
            gradeCalculator.Score = 65;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("C",result);
        }
        [Fact]
        public void GrandeB_Attendes65()
        {
            gradeCalculator.Score = 85;
            gradeCalculator.AttandancePercentage = 65;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("B",result);
        }
        [Fact]
        public void Score95_Attendes55()
        {
            gradeCalculator.Score = 95;
            gradeCalculator.AttandancePercentage = 55;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("F",result);
        }
        [Fact]
        public void Score65_Attendes55()
        {
            gradeCalculator.Score = 65;
            gradeCalculator.AttandancePercentage = 55;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("F",result);
        }
        [Fact]
        public void Score50_Attendes55()
        {
            gradeCalculator.Score = 50;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.Equal("F",result);
        }

        /// OR DO LİKE THİS
        /// 
        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 65, "B")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GradeCalculatorMultipleTest(int score, int attendance, string expectedResult)
        {
            gradeCalculator.Score = score;
            gradeCalculator.AttandancePercentage = attendance;
            var result = gradeCalculator.GetGrade();
            Assert.Equal(expectedResult,result);
        }


    }
}

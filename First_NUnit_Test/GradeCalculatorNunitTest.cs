using First_Unit_Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_NUnit_Test
{
    public class GradeCalculatorNunitTest
    {
        private GradeCalculator gradeCalculator;
        [SetUp]
        public void Setup()
        {
            gradeCalculator = new GradeCalculator();
        }
        [Test]
        public void GradeA_Attendees90()
        {
            gradeCalculator.Score = 95;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }
        [Test]
        public void GradeB_Attendees90()
        {
            gradeCalculator.Score = 85;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B")); 
        }
        [Test]
        public void GradeC_Attendees90()
        {
            gradeCalculator.Score = 65;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }
        [Test]
        public void GrandeB_Attendes65()
        {
            gradeCalculator.Score = 85;
            gradeCalculator.AttandancePercentage = 65;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }
        [Test]
        public void Score95_Attendes55()
        {
            gradeCalculator.Score = 95;
            gradeCalculator.AttandancePercentage = 55;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
        [Test]
        public void Score65_Attendes55()
        {
            gradeCalculator.Score = 65;
            gradeCalculator.AttandancePercentage = 55;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
        [Test]
        public void Score50_Attendes55()
        {
            gradeCalculator.Score = 50;
            gradeCalculator.AttandancePercentage = 90;
            string result = gradeCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }

        /// OR DO LİKE THİS
        /// 
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalculatorMultipleTest(int score, int attendance)
        {
            gradeCalculator.Score = score;
            gradeCalculator.AttandancePercentage = attendance;
            return gradeCalculator.GetGrade();
        }


    }
}

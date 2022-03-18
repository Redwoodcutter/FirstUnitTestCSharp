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
    [TestFixture]
    public class BankAccountNunitTests
    {
        private BankAccount bankAccount;
        [SetUp]
        public void setup()
        {
            //bankAccount = new(new LogFakker());
        }
        //[Test]
        //public void BankDepositAdd_ReturnTrue_100_Fakker()
        //{
        //    BankAccount bankAccount = new(new LogFakker());
        //    var result = bankAccount.Depozit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}
        [Test]
        public void BankDepositAdd_ReturnTrue_100()
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Depozit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
        [Test]
        [TestCase(200,100)]
        [TestCase(300,100)]
        [TestCase(100,50)]
        public void BankWithDraw_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x>0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
             bankAccount.Depozit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);

        }
        [Test]
        [TestCase(200, 1100)]
        [TestCase(300, 400)]
        [TestCase(100, 150)]
        public void BankWithDraw_ReturnFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILookBook>();
           
            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(false);
            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);
            //logMock.Setup(x => x.logBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Depozit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(result);

        }

        [Test]
        public void BankLogDummy_LogString_True()
        {
            var logMock = new Mock<ILookBook>();
            string DesiredOutput = "hello";

            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(DesiredOutput));
        }

        [Test]
        public void BankLogDummy_LogOutputString_True()
        {
            var logMock = new Mock<ILookBook>();
            string DesiredOutput="hello";

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out DesiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Oguz", out result));
            Assert.That(result, Is.EqualTo(DesiredOutput));
        }
        [Test]
        public void BankLogDummy_LogRefCheck_True()
        {
            var logMock = new Mock<ILookBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
        }
        [Test]
        public void BankLogDummy_SetGetLogType_MockTest()
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");
            logMock.SetupAllProperties();
            logMock.Object.LogSeverity = 100;
            logMock.Object.LogType = "warning";

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));


            // Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Oguz");
            Assert.That(logTemp, Is.EqualTo("Hello, Oguz"));

            // Callbacks
            int Count = 10;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => Count++);

            logMock.Object.LogToDb("Oguz");
            logMock.Object.LogToDb("Oguz");
            logMock.Object.LogToDb("Oguz");
            Assert.That(Count, Is.EqualTo(13));
        }
        [Test]
        public void BankLogDummy_Verify()
        {
            var logMock = new Mock<ILookBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Depozit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u=>u.LogSeverity=101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }
    }
}

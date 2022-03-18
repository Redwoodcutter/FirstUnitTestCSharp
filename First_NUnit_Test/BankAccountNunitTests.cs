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

    }
}

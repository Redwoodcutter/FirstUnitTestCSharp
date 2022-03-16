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
        [Test]
        public void BankDepositAdd_ReturnTrue_100_Fakker()
        {
            BankAccount bankAccount = new(new LogFakker());
            var result = bankAccount.Depozit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }
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
    }
}

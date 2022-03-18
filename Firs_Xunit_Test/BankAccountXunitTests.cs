using First_Unit_Test;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace First_NUnit_Test
{
  
    public class BankAccountXunitTests
    {
        private BankAccount bankAccount;
     
        [Fact]
        public void BankDepositAdd_ReturnTrue_100()
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);
            var result = bankAccount.Depozit(100);
            Assert.True(result);
            Assert.Equal(100,bankAccount.GetBalance());
        }
        [Theory]
        [InlineData(200, 100)]
        [InlineData(300, 100)]
        [InlineData(100, 50)]
        public void BankWithDraw_ReturnTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Depozit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.True(result);

        }
        [Theory]
        [InlineData(200, 1100)]
        [InlineData(300, 400)]
        [InlineData(100, 150)]
        public void BankWithDraw_ReturnFalse(int balance, int withdraw)
        {
            var logMock = new Mock<ILookBook>();

            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(false);
            logMock.Setup(x => x.logBalanceAfterWithdraw(It.Is<int>(x => x < 0))).Returns(false);
            //logMock.Setup(x => x.logBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Depozit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.False(result);

        }

        [Fact]
        public void BankLogDummy_LogString_True()
        {
            var logMock = new Mock<ILookBook>();
            string DesiredOutput = "hello";

            logMock.Setup(x => x.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.Equal(logMock.Object.MessageWithReturnStr("HELLo"), DesiredOutput);
        }

        [Fact]
        public void BankLogDummy_LogOutputString_True()
        {
            var logMock = new Mock<ILookBook>();
            string DesiredOutput = "hello";

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out DesiredOutput)).Returns(true);
            string result = "";
            Assert.True(logMock.Object.LogWithOutputResult("Oguz", out result));
            Assert.Equal(result, DesiredOutput);
        }
        [Fact]
        public void BankLogDummy_LogRefCheck_True()
        {
            var logMock = new Mock<ILookBook>();
            Customer customer = new();
            Customer customerNotUsed = new();

            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);

            Assert.False(logMock.Object.LogWithRefObj(ref customerNotUsed));
            Assert.True(logMock.Object.LogWithRefObj(ref customer));
        }
        [Fact]
        public void BankLogDummy_SetGetLogType_MockTest()
        {
            var logMock = new Mock<ILookBook>();
            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");
            logMock.SetupAllProperties();
            logMock.Object.LogSeverity = 100;
            logMock.Object.LogType = "warning";

            Assert.Equal(100,logMock.Object.LogSeverity );
            Assert.Equal("warning",logMock.Object.LogType);


            // Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Oguz");
            Assert.Equal("Hello, Oguz",logTemp);

            // Callbacks
            int Count = 10;
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => Count++);

            logMock.Object.LogToDb("Oguz");
            logMock.Object.LogToDb("Oguz");
            logMock.Object.LogToDb("Oguz");
            Assert.Equal(13,Count);
        }
        [Fact]
        public void BankLogDummy_Verify()
        {
            var logMock = new Mock<ILookBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Depozit(100);
            Assert.Equal(100,bankAccount.GetBalance());

            //verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);
        }
    }
}

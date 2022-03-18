using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public class BankAccount
    {
        public int balance { get; set; }
        private readonly ILookBook _logBook;

        public BankAccount(ILookBook logBook)
        {
            _logBook = logBook;
            balance = 0;
        }
        public bool Depozit (int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            var temp = _logBook.LogSeverity;
            balance += amount;
            return true;
        }
        public bool Withdraw(int amount)
        {
            if(amount<0)
            {
                _logBook.LogToDb("Withdraw Amount: " + amount.ToString());
                balance -= amount;
                return _logBook.logBalanceAfterWithdraw(balance);
            }
            return _logBook.logBalanceAfterWithdraw(balance-amount);
        }
        public int GetBalance()
        {
            return balance;
        }
    }
}

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
            balance += amount;
            return true;
        }
        public bool Withdraw(int amount)
        {
            if(amount<0)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
        public int GetBalance()
        {
            return balance;
        }
    }
}

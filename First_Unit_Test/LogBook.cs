using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public interface ILookBook
    {
        void Message(string message);

        bool LogToDb(string message);

        bool logBalanceAfterWithdraw(int balanceAfterWithdraw);
        
        string MessageWithReturnStr(string message);
    }
    public class LogBook : ILookBook
    {
        public bool logBalanceAfterWithdraw(int balanceAfterWithdraw)
        {
           if(balanceAfterWithdraw >= 0)
            {
                Console.WriteLine("Success");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }
    //public class LogFakker : ILookBook
    //{
    //    public void Message(string message)
    //    {
    //    }
    //}
}

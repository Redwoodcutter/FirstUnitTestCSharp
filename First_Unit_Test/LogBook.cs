using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public interface ILookBook
    {
        int LogSeverity { get; set; }
        string LogType { get; set; }
        void Message(string message);

        bool LogToDb(string message);

        bool logBalanceAfterWithdraw(int balanceAfterWithdraw);
        
        string MessageWithReturnStr(string message);

        bool LogWithOutputResult(string str, out string outputStr);

        bool LogWithRefObj(ref Customer customer);
    }
    public class LogBook : ILookBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

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

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello" + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {
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

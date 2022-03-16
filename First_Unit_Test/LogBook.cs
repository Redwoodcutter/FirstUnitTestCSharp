using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public interface ILookBook
    {
        void Message(string message);
    }
    public class LogBook : ILookBook
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class LogFakker : ILookBook
    {
        public void Message(string message)
        {
        }
    }
}

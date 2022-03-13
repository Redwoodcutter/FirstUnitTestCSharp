using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public class Customer
    {
        public int Discount = 15;
        public string GreetingMessage { get; set; }
        public string GreatingWithNames ( string firstName, string lastName)
        {
            GreetingMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetingMessage;
        }
    }
}

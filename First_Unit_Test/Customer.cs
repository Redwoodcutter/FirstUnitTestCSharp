using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public class Customer
    {
        public string GreatingWithNames ( string firstName, string lastName)
        {
            return $"Hello, {firstName} {lastName}";
        }
    }
}

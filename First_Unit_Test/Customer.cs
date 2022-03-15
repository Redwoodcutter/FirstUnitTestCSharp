using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public class Customer
    {
        public int OrderTotal { get; set; }

        public int Discount = 15;
        public string GreetingMessage { get; set; }
        public string GreatingWithNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First Name");
            }
            GreetingMessage = $"Hello, {firstName} {lastName}";
            Discount = 20;
            return GreetingMessage;
        }
        public CustomerType GetCustomerDetails()
        {
            if(OrderTotal<100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }
    }
    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}

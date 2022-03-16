using System;
using System.Collections.Generic;
using System.Text;

namespace First_Unit_Test
{
    public interface ICustomer
    {
        int Discount { get; set; }
        int OrderTotal { get; set; }
        string GreetingMessage { get; set; }
        bool IsPlatinum { get; set; }

        string GreatingWithNames(string firstName, string lastName);
        CustomerType GetCustomerDetails();
    }
        public class Customer : ICustomer
    {
        public int OrderTotal { get; set; }

        public int Discount { get; set; }
        public string GreetingMessage { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            Discount = 15;
            IsPlatinum = false;
        }
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

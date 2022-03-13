using System;

namespace First_Unit_Test
{
    public class Calculator
    {
        public int AddNumbers(int a , int b)
        {
            return a + b;
        }
        public double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }
        public bool IsOddNumbers(int a)
        {
            return a % 2 != 0;       
        }

    }
}

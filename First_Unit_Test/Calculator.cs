using System;
using System.Collections.Generic;

namespace First_Unit_Test
{
    public class Calculator
    {
        public List<int> numberRange = new List<int>();

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
        public List <int> getOddRange(int min, int max)
        {
            numberRange.Clear();
            for(int i = min ; i <= max; i++)
            {
                if (i % 2 != 0)
                {
                    numberRange.Add(i);
                }
            }
            return numberRange;
        }

    }
}

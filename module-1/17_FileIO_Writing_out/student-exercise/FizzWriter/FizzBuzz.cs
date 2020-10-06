using System;
using System.Collections.Generic;
using System.Text;

namespace FizzWriter.Classes
{
    public static class FizzBuzz
    {
        public static string GetFizzBuzz(int number)
        {
            bool isDivisibleBy3 = FizzBuzz.GetDivisibleBy3(number);
            bool isDivisibleBy5 = FizzBuzz.GetDivisibleBy5(number);

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                return "FizzBuzz";
            }
            else if (isDivisibleBy3 && !isDivisibleBy5)
            {
                return "Fizz";
            }
            else if (isDivisibleBy5 && !isDivisibleBy3)
            {
                return "Buzz";
            }
            else
            {
                return number.ToString();
            }
        }

        private static bool GetDivisibleBy3(int number)
        {
            if (number % 3 == 0)
            {
                return true;
            }
            return false;
        }

        private static bool GetDivisibleBy5(int number)
        {
            if (number % 5 == 0)
            {
                return true;
            }
            return false;
        }
    }
}
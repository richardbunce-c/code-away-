using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Hello, what is your name? ");

            //// Read input from the user
            //string userName = Console.ReadLine();

            //Console.WriteLine($"Hi {userName}, nice to meet you!");
            //Console.Write("How old are you? ");

            //string ageAsString = Console.ReadLine();
            //double age = double.Parse(ageAsString);

            //Console.WriteLine($"Wow, in ten years, you will be {age+10} years old!");

            //Console.Write("Who are your kids (comma-separated)? ");
            //string kidsAsString = Console.ReadLine();
            //string[] kids = kidsAsString.Split(",");

            //Console.WriteLine("These are your children:");
            //for (int i = 0; i < kids.Length; i++)
            //{
            //    Console.WriteLine(kids[i]);
            //}


            Console.WriteLine("Enter some numbers, separated by space");
            string input = Console.ReadLine();

            string[] stringNumbers = input.Split(" ");

            int sum = 0;

            for (int i = 0; i < stringNumbers.Length; i++)
            {
                // Convert the string to an int
                int n = int.Parse(stringNumbers[i]);

                // Add it to the sum
                sum = sum + n;  // or, sum += n;
            }

            Console.WriteLine($"There are {stringNumbers.Length} numbers totalling {sum}, and averaging { (double)sum / stringNumbers.Length}");


        }
    }
}

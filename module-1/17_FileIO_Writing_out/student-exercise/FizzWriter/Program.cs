
using System;
using FizzWriter.Classes;
using System.IO;

namespace FizzWriter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = "FizzBuzz.txt";
            int numbers = 1;

            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    while (numbers <= 300)
                    {
                        string result = FizzBuzz.GetFizzBuzz(numbers);

                        sw.WriteLine($"{numbers}: {result}");

                        numbers++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine($"{filename} has been created.");
        }
    }
}

using System;
using FizzWriter.Classes;
using System.IO;
using System.Runtime.CompilerServices;

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

///worked on in class
//            {
//                string filePath = "fizzBuzz.txt";

//                if (!File.Exists("Readme.md"))
//                {
//                    filePath = Path.Combine(filePath, @"..\..\..\..");


//                }
//                using (StreamWriter sw = new StreamWriter(filePath, false))
//                {
//                    sw.WriteLine("I wrote this line to the file!");
//                }
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lecture.Aids
{
    public class SummingUpNumbers
    {
        public void ReadFile()
        {
            // Reading in a file of numbers
            string folder = Environment.CurrentDirectory;
            string filename = @"..\..\..\Files\numbers.txt";
            // get the full path
            string fullpath = Path.Combine(folder, filename);

            int sum = 0;
            using (StreamReader sr = new StreamReader(fullpath))
            {
                // Read until we get to the end of the file
                while (!sr.EndOfStream)
                {
                    // Read the line
                    string line = sr.ReadLine();
                    // Convert to a number

                    try
                    {
                        int number = int.Parse(line);
                        // Add to Sum
                        sum += number;
                    }
                    catch( FormatException formatException)
                    {
                        Console.WriteLine($"Warning: could not parse line {line} into an integer, skipping...");
                    }
                    finally
                    {
                        Console.WriteLine("finally...");
                    }
                }
            }
            
            Console.WriteLine("The sum is " + sum);
        }
    }
}

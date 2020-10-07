using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLines;


            string directory = Environment.CurrentDirectory;
            string inputFile;
            string outputFile;
            string inputFullPath;
            string outputFullPath;

            Console.WriteLine("What is the input file(please include the path to the file)?   ");
            inputFile = Console.ReadLine();
            inputFile = "input.txt";
            outputFile = inputFile;

            inputFullPath = Path.Combine(directory, inputFile);

            Console.Write("How many lines of text (max) should there be in the split files? ");
            maxLines = int.Parse(Console.ReadLine());

            using (StreamReader sr = new StreamReader(inputFullPath))
            {
                int totalLines = 0;
                int numOutputFiles;

               
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();

                    totalLines++;
                }

             
                sr.DiscardBufferedData();
                sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
              

                numOutputFiles = totalLines / maxLines;

                if (totalLines % maxLines != 0)
                {
                    numOutputFiles++;
                }

                Console.WriteLine();
                Console.WriteLine("For a " + totalLines + " line input file " +
                    "\"" + inputFile + "\" this produces " + numOutputFiles
                    + " output files.");

                int index = inputFile.IndexOf(".");
                Console.WriteLine("**GENERATING OUTPUT**");
                 Console.ReadLine();

                for (int i = 1; i <= numOutputFiles; ++i)
                {
                    outputFile = inputFile.Substring(0, index) + "-" + i.ToString() + ".txt";
                    outputFullPath = Path.Combine(directory, outputFile);
                    using (StreamWriter sw = new StreamWriter(outputFullPath))
                    {
                        for (int j = 1; j <= maxLines && !sr.EndOfStream; ++j)
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                    Console.WriteLine("Generating " + outputFile);
                }

                Console.ReadLine();
            }
        }
    }
}

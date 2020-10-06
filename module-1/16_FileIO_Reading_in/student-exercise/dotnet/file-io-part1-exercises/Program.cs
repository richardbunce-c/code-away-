using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Environment.CurrentDirectory;
            string file = "sample-quiz-file.txt";
            string fullPath = Path.Combine(dir, file);

            using (StreamReader sr = new StreamReader(fullPath))
            {
                int lineCount = 0;
                int score = 0;
                while (!sr.EndOfStream)
                {
                    lineCount++;
                    int correctA = 0;
                    string[] thisQa = sr.ReadLine().Split('|');
                    Console.WriteLine(thisQa[0]);
                    int qNum = 1;
                    for (int i = 1; i < thisQa.Length; i++)
                    {
                        if (thisQa[i].Contains("*"))
                        {
                            correctA = i;
                        }
                        string displayQ = thisQa[i].Replace("*", "");
                        Console.WriteLine($"{qNum}. {displayQ}");
                        qNum++;
                    }
                    Console.WriteLine();
                    int userA = int.Parse(Console.ReadLine());
                    if (thisQa[userA].Contains("*"))
                    {
                        Console.WriteLine("RIGHT!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"WRONG!");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"You got {score} answer(s) correct out of {lineCount} questions asked.");
                Console.ReadLine();
            }
        }
    }
}
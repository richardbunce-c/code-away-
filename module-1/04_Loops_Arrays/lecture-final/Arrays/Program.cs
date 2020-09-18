using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Creating an array of integers
            int[] scores;
            scores = new int[5];
            scores[0] = 95;
            scores[1] = 57;
            scores[2] = 78;
            scores[3] = 89;
            scores[4] = 100;

            //2. Creating an array of strings
            string[] days = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            //3. Create an array of characters that hold "Tech Elevator"        
            char[] charName = new char[] { 'M', 'i', 'k', 'e' };

            //4. Print out the first item in each array
            Console.WriteLine(scores[0]);
            Console.WriteLine(days[0]);
            Console.WriteLine(charName[0]);

            //5. Print out the 3rd item in each array
            Console.WriteLine(days[2]);

            //6. Get the length of each array
            Console.WriteLine(scores.Length);
            Console.WriteLine(days.Length);
            Console.WriteLine(charName.Length);

            //7. Get the last index 
            int secondToLastIndex = days.Length - 2;

            Console.WriteLine($"Last index of days = {days.Length - 1}");
            // 7a. Get the last element
            Console.WriteLine($"Last element of days = {days[days.Length - 1]}");
            Console.WriteLine($"2nd to Last element of days = {days[secondToLastIndex]}");

            //8. Update the last item in each array
            scores[scores.Length - 1] += 10;

            Console.WriteLine(scores[scores.Length - 1]);



            // LOOPS

            // Print "Hello" 10 times
            for (int counter = 1; counter <= 10; counter++)
            {
                Console.WriteLine("Hello!");
            }

            // Loop though the scores array, and print each score
            // Let's get an average of scores
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine($"The score at index {i} is {scores[i]}");

                sum += scores[i];

            }

            double averageScore = ((double)sum) / scores.Length;

            Console.WriteLine($"Average score is {averageScore}");


            // Is there any zeroes in the group?


        }
    }
}

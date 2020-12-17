using System;

namespace MartianWeight
{
    /*
    In case you've ever pondered how much you weight on Mars, here's the calculation:
    Wm = We* 0.378
    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

    Write a command line program which accepts a series of Earth weights from the user  
    and displays each Earth weight as itself, and its Martian equivalent.


    C:\Users> MartianWeight  
    Enter a series of Earth weights (space-separated): 98 235 185

    98 lbs.on Earth, is 37 lbs.on Mars.
    235 lbs.on Earth, is 88 lbs.on Mars.
    185 lbs.on Earth, is 69 lbs.on Mars. 
    */
    class Program
    {
        static void Main(string[] args)
        {
             double conversionVariable = .378;
 

            Console.Write("Enter a series of Earth Weights (Space Separated)");
            string weightString = Console.ReadLine();
            string[] weightStringArray = weightString.Split();
             for (int i = 0; i < weightStringArray.Length; i++)
            {
                string toParse = weightStringArray[i];
                double beenParsed = double.Parse(toParse);
                double beenConverted = conversionVariable * beenParsed;
               Console.WriteLine(beenParsed+" lbs. on Earth, is "+beenConverted+" lbs. on Mars.");
            }
        }
    }
}

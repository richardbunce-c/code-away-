using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the temperature");
            string inputTemp = Console.ReadLine();



            Console.WriteLine("Is the temperature in (C)elsius, or (F)ahrenheit?");
            string inputFC = Console.ReadLine();
            
            double outputTemp;

            if (inputFC.ToLower() == "f" )
            {
                
                outputTemp = (Convert.ToDouble(inputTemp) - 32) / 1.8;
                Console.WriteLine(inputTemp + "F" + " is " + outputTemp + "C");
            }

            else if (inputFC.ToLower() == "c")
            {
                outputTemp = (Convert.ToDouble(inputTemp)) * 1.8 + 32;
                Console.WriteLine(inputTemp + "C" + " is " + outputTemp + "F");
            }
       ////else
       //     {
       //         Console.WriteLine("You need to choose either f or c!!");
       //     }
        }
    }
}

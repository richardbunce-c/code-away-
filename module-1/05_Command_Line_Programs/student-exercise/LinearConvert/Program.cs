using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the length:");
            string inputLength = Console.ReadLine();



            Console.WriteLine("Is the measurement in (m)eters or (f)eet?");
            string inputMF = Console.ReadLine();

            double outputMF;

            if (inputMF.ToLower() == "m")
            {

                outputMF = (Convert.ToDouble(inputLength))*3.2808399;
                Console.WriteLine(inputLength + "m" + " is " + outputMF + "f.");
            }

            else if (inputMF.ToLower() == "f")
            {
                outputMF = (Convert.ToDouble(inputLength)) *0.3048;
                Console.WriteLine(inputLength + "f" + " is " + outputMF + "m.");
            }
        }
    }
}

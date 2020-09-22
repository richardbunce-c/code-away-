using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter a list of names: ");

            string input = " Taylor, Keith, Richard, Dean";
            char[] separators = new char[] { ' ', ';', ':', '|' };
            string[] names = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < names.Length; i++)


            {
                string name = names[i].Trim();
                //Console.WriteLine(names+",");
                if (i == 0)
                {
                    Console.Write(name);
                }

                else
                {
                    Console.Write($", {name}");
                }

                //This is how a split works

            }
            Console.WriteLine("===============");
            Console.WriteLine(string.Join(", ", names));

        }


    }
}

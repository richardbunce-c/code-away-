using System;

namespace command_line_input_exercises_pairs
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.

        C:\Users> MakeChange

        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            decimal changeDecimal;
            decimal billDecimal;
            decimal tenderDecimal;
           

            Console.Write("Please enter the amount of the bill:");
           string bill = Console.ReadLine();
            billDecimal =Decimal.Parse( bill);
            Console.Write("Please enter the amount tendered:");
            string tender = Console.ReadLine();
            tenderDecimal = Decimal.Parse(tender);
            changeDecimal = (tenderDecimal - billDecimal);
            Console.WriteLine("The change required is "+changeDecimal);
            

          
          

           
            {
               
            }

            
        }
    }
}

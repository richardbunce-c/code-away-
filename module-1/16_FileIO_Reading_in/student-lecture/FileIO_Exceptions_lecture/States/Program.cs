using States.Model;
using System;
using System.Collections.Generic;

namespace States
{
    class Program
    {
        // Declare and create a dictionary to hold state codes and names
        static private StateDictionary stateCodes;
        static void Main(string[] args)
        {
            LoadStateDictionary();
            while (true)
            {
                Console.Write("Please enter a state code (Q to Quit): ");
                string stateCode = Console.ReadLine().ToUpper().Trim();

                if (stateCode == "Q")
                {
                    break;
                }

                State state = LookupStateName(stateCode);

                if (state == null)
                {
                    Console.WriteLine($"Code {stateCode} was not found");
                }
                else
                {
                    Console.WriteLine($"The name of the state with code '{stateCode}' is {state.Name}. Its capital is {state.Capital}, and the its largest city is {state.LargestCity}.");
                }
            }

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void LoadStateDictionary()
        {
            // TODO 22: Replace this hard-coded data with a call to the StateFileLoader.

            stateCodes = new StateDictionary(
                new List<State>()
                {
                    new State("OH", "Ohio", "Cleveland", "Timberlake"),
                    new State("FL", "Florida", "Disney World", "Shady Oaks Retirement Community")
                }
            );
        }

        static public State LookupStateName(string stateCode)
        {
            // Lookup the given state code in the State Dictionary
            if (stateCodes.ContainsKey(stateCode))
            {
                return stateCodes[stateCode];
            }
            else
            {
                return null;
            }
        }
    }
}

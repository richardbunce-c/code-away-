using MenuFramework;
using States.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace States
{
    class Program
    {
        static private string stateOrProvince = "state";

        // Declare and create a dictionary to hold state codes and names
        static private StateDictionary stateCodes;

        static void Main(string[] args)
        {
            LoadStates();

            ConsoleMenu menu = new ConsoleMenu();
            menu.AddOption("Choose Input File", SelectInput)
                .AddOption("Find a state", FindState)
                .AddOption("List states", ListStates)
                .AddOption("Exit", Exit);

            menu.Configure(config =>
           {
               config.ItemForegroundColor = ConsoleColor.Green;
               config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;
               config.SelectedItemForegroundColor = ConsoleColor.White;
               config.Title = "State Code Lookup";
           });

            menu.Show();

            Console.WriteLine("Thanks for using our awesome program! Press any key to exit.");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static MenuOptionResult Exit()
        {
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        private static MenuOptionResult SelectInput()
        {
            ConsoleMenu fileMenu = new ConsoleMenu()
                .AddOption("US States", LoadStates)
                .AddOption("Canadian Provinces", LoadProvinces)
                .AddOption("Cancel", Exit)
                .Configure(config =>
                {
                    config.ItemForegroundColor = ConsoleColor.Cyan;
                    config.SelectedItemBackgroundColor = ConsoleColor.DarkCyan;
                    config.SelectedItemForegroundColor = ConsoleColor.White;
                    config.Title = "Load Input File";
                });

            fileMenu.Show();

            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        private static MenuOptionResult FindState()
        {
            string stateCode = ConsoleMenu.GetString($"Please enter a {stateOrProvince} code (Enter to cancel)", true);

            if (stateCode == "")
            {
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }

            State state = LookupStateName(stateCode);

            if (state == null)
            {
                Console.WriteLine($"Code '{stateCode}' was not found");
            }
            else
            {
                Console.WriteLine($"The name of the state with code '{stateCode}' is {state.Name}. Its capital is {state.Capital}, and the its largest city is {state.LargestCity}.");
            }

            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private static MenuOptionResult ListStates()
        {
            string startsWith = ConsoleMenu.GetString($"Find {stateOrProvince}s that start with (Enter for all)", true);

            foreach (State val in stateCodes.Values)
            {
                if (val.Name.StartsWith(startsWith, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"\t{val.StateCode} {val.Name}");
                }
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private static MenuOptionResult LoadStates()
        {
//            LoadStateDictionary(@"..\..\..\USStates.txt");
            LoadStateDictionary("USStates.txt");
            stateOrProvince = "state";
            return MenuOptionResult.CloseMenuAfterSelection;
        }
        private static MenuOptionResult LoadProvinces()
        {
            LoadStateDictionary("CanadianProvinces.txt");
            stateOrProvince = "province";
            return MenuOptionResult.CloseMenuAfterSelection;
        }

        private static void LoadStateDictionary(string fileName)
        {
            StateFileLoader loader = new StateFileLoader(fileName);
            stateCodes = new StateDictionary(loader.StateList);
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

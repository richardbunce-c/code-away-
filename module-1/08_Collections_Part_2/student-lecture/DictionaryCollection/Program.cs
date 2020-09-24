using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string stateCode = "AR";

            //string state = LookupState(stateCode);
            string state = LookupUsingDictionary(stateCode);

            Console.WriteLine($"The state for code '{stateCode}' is '{state}'");

            //HashSetDemo();

            // Build a name / height database and search it
            // RunHeightDatabase();
        }

        static string LookupState(string stateCode)
        //Given a state code, ruturn a state name as well
        {
            List<string> stateCodes = new List<string>() { "AL", "AK", "AR", "AZ", "CA", "CO", "CT", "DE" };
            List<string> stateNames = new List<string>() { "Alabama", "Alaska", "Arkansas", "Arizona", "California", "Colorado",
                 "Connecticut", "Deleware" };

            //Find the Index in stateCodes that matches the code passed in 
            int stateIndex = stateCodes.IndexOf(stateCode.ToUpper());

            if (stateIndex < 0)
            {
                return "";
            }

            //Return the string in stateNames at that index
            return stateNames[stateIndex];
        }
        static string LookupUsingDictionary(string stateCode)
        {
            // Demonstrate creating and searching a dictionary
            Dictionary<string, string> states = new Dictionary<string, string>()
             {
                 {"AL" , "Alabama"},
                 {"AK", "Alaska" },
                 {"AR", "Arkansas" },
                 {"AZ", "Arizona" },
                 {"CA", "California" },
                 {"CO", "Colorado" },
                 {"CT", "Connecticut" },
                 {"DE", "Deleware" },
             };
            //// Add more to dictionary
            states.Add("OH", "Ohio");
            states["MI"] = "Michigan";

            if (!states.ContainsKey(stateCode.ToUpper()))
            {
                return "";
            }

            return states[stateCode.ToUpper()];
        }

        static void HashSetDemo()
        {
            // Demonstrate a few HashSet methods

        }
        static void RunHeightDatabase()
        {
            // Display a greeting and menu

            //// 1. Let's create a new Dictionary that could hold string, ints
            ////      | "Josh"    | 70 |
            ////      | "Bob"     | 72 |
            ////      | "John"    | 75 |
            ////      | "Jack"    | 73 |
            Dictionary<string, int> heightDB = null; new Dictionary<string, int>()
            {
                {"Brad", 78 },
                {"Brian",72 },
                {"Zoe", 70 },
                {"Reta", 65 },
                {"TaylorP", 64},
                {"RichardB", 72 },
            };
            
            string input;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"     _       _        _                    ");
                Console.WriteLine(@"    | |     | |      | |                   ");
                Console.WriteLine(@"  __| | __ _| |_ __ _| |__   __ _ ___  ___ ");
                Console.WriteLine(@" / _` |/ _` | __/ _` | '_ \ / _` / __|/ _ \");
                Console.WriteLine(@"| (_| | (_| | || (_| | |_) | (_| \__ \  __/");
                Console.WriteLine(@" \__,_|\__,_|\__\__,_|_.__/ \__,_|___/\___|");
                Console.WriteLine(@"                                           ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1) Add / update data");
                Console.WriteLine("2) Search the database");
                Console.WriteLine("3) Print the database");
                Console.WriteLine("4) Get Average Height");
                Console.WriteLine("Q) Quit");
                Console.WriteLine("");
                Console.ResetColor();
                Console.Write("Please enter selection: ");
                input = Console.ReadLine().ToLower();
                if (input.Length > 0)
                {
                    input = input.Substring(0, 1);
                }
                if (input == "q")
                {
                    break;
                }
                else if (input == "1")
                {
                    AddEditDB(heightDB);
                }
                else if (input == "2")
                {
                    SearchDB(heightDB);
                }
                else if (input == "3")
                {
                    PrintDB(heightDB);
                }
                else if (input == "4")
                {
                    ShowAverageHeight(heightDB);
                }
                else
                {
                    continue;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("Done...");


        }

        public static void ShowAverageHeight(Dictionary<string, int> heightDB)
        {
            //7. Let's get the average height of the people in the dictionary
            //Initialize a sum
            int totalHeight = 0;
            //Loop and total up a sum of heights
            foreach(KeyValuePair<string, int> kvp in heightDB)
            {
                totalHeight += kvp.Value;
            }
            //Calculate average by dividing total height by Count
        double avgHeight = (double)totalHeight / heightDB.Count;
            Console.WriteLine($"The average height is {avgHeight} inches.");
        }
        
        public static void PrintDB(Dictionary<string, int> heightDB)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            Console.WriteLine("Printing...");


            foreach(KeyValuePair<string, int> kvp in heightDB)
            {
                Console.WriteLine($"Name: {kvp.Key}, Height:{kvp.Value}");
            }
        }

        public static void AddEditDB(Dictionary<string, int> db)
        {
            Console.Write("What is the person's name?: ");
            string name = Console.ReadLine();

            Console.Write("What is the person's height (in inches)?: ");
            int height = int.Parse(Console.ReadLine());



            // 2. Check to see if that name is in the dictionary
            //      bool exists = dictionaryVariable.ContainsKey(key)
            bool exists = db.ContainsKey(name);    // <-- change this....changed it

            if (!exists)
            {
                Console.WriteLine($"Adding {name} with new value.");
                // 3. Put the name and height into the dictionary
                //      dictionaryVariable[key] = value;
                //      OR dictionaryVariable.Add(key, value);
                db.Add(name, height);
            }
            else
            {
                Console.WriteLine($"Overwriting {name} with new value.");
                // 4. Overwrite the current key with a new value
                //      dictionaryVariable[key] = value;
                db[name] = height;
            }
        }
        public static void SearchDB(Dictionary<string, int> db)
        {
            Console.Write("Which name are you looking for? ");
            string input = Console.ReadLine();

            //5. Let's get a specific name from the dictionary
            if (db.ContainsKey(input))
            {
                Console.WriteLine($"{input} was found, and is {db[input]} inches tall.");
            }
            else
            {
                Console.WriteLine($"{input} was not found in the database!");
            }

        }
    }
}

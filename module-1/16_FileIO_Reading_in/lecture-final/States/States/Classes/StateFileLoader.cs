using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace States.Classes
{
    class StateFileLoader
    {
        public List<State> StateList { get; set; }
        public StateFileLoader(string filePath)
        {
            StateList = new List<State>();

            try
            {

                // TODO 01: Open the file, read each line, parse it, and load up a list of states.
            // TODO 02: Add exception handling so the program does not blow up with file error
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string input = reader.ReadLine();
                        string[] fields = input.Split("|");
                        State state = new State(fields[1], fields[0], fields[2], fields[3]);
                        StateList.Add(state);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There was an error loading the State list: {ex.Message}");
            }

        }
    }
}

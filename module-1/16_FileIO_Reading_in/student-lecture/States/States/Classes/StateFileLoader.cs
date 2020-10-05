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
            StateList = new List<State>()
            {
                new State("OH", "Ohio", "Cleveland", "Timberlake"),
                new State("FL", "Florida", "Disney World", "Shady Oaks Retirement Community")
            };

            // TODO 01: Open the file, read each line, parse it, and load up a list of states.

            // TODO 02: Add exception handling so the program does not blow up with file error
        }
    }
}

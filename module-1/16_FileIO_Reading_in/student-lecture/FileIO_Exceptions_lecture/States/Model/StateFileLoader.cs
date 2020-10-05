using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace States.Model
{
    class StateFileLoader
    {
        public List<State> StateList { get; set; }
        public StateFileLoader(string filePath)
        {
            // TODO 21: Open the file, read each line, parse it, and load up a list of states.
            StateList = new List<State>();
        }
    }
}

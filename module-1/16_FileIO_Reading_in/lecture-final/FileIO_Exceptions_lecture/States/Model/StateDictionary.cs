using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace States.Model
{
    class StateDictionary : Dictionary<string, State>
    {
        public StateDictionary(IEnumerable<State> states) : base(StringComparer.InvariantCultureIgnoreCase)
        {
            foreach (State state in states)
            {
                this.Add(state.StateCode, state);
            }
        }
    }
}

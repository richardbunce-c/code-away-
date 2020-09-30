using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Goat : FarmAnimal
    {
        public Goat() : base("GOAT") { }

        public override string MakeSound()
        {
            return "Bleet";
        }
    }
}

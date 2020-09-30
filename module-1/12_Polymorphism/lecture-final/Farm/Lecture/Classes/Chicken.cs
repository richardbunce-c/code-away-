using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Chicken : FarmAnimal
    {
        public Chicken() : base("CHICKEN") { }

        public override string MakeSound()
        {
            return "Cluck!";
        }
    }
}

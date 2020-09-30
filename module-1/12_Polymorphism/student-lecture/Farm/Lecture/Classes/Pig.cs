using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Pig: FarmAnimal
    {
        public Pig() :base("PIG") { }

        public override string MakeSound()
        {
            return "Oink";
        }
    }
}

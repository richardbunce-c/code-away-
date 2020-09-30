using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Cow:FarmAnimal
    {
        public Cow():base("COW"){}
            public override string MakeSound()
        {
            return "Moo";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
   public class Horse:FarmAnimal
    {
        public Horse():base("HORSE"){}
            public override string MakeSound()
        {
            return "Neigh";
        }
    }
}

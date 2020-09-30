using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public class Tractor : ISingable
    {
        public string Name { get; } = "TRACTOR";

        public string MakeSound()
        {
            return "Vroom!";
        }

        public string MakeSoundTwice()
        {
            return "Vroom Vroom!";
        }
    }
}

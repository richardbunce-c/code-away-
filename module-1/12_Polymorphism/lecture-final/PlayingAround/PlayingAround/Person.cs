using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingAround
{
    class Person
    {
        public static int staticField = 50;
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, staticField: {staticField}";
        }
    }
}

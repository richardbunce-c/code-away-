using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    abstract public class Wall
    {
       //Readonly prop for wall name
        public string Name { get; }
       //Readonly prop for Color
        public string Color { get; }

        public Wall(string name, string color)
        {
            Name = name;
            Color = color;
        }



        abstract public int GetArea();
        
       
    
        }
    }


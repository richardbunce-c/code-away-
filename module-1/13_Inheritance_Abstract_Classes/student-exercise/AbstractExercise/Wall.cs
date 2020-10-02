using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExercise
{
    abstract public class Wall
    {
        //public string Name { get; }
        // public string Color { get; }

        public Wall(string name, string color)
        { }



        abstract public int GetArea();
        
       
    
        }
    }


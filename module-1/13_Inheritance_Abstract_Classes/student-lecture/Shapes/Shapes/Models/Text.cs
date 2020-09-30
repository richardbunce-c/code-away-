using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /**********************
     * This is a Text class which displays a string on the screen.
     * It IS NOT a 2D Shape (does not have an area or perimeter for instance).  So we use the IDrawwable interface to 
     * say that indeed we can draw this class on a screen.
     * 
     **********************/
    public class Text : IDrawable
    {
        public string Label { get; set; }
        public ConsoleColor Color { get; set; }

        public Text(string label, ConsoleColor color)
        {
            Label = label;
            Color = color;
        }

        public override string ToString()
        {
            return $"A {Color} Text Label";
        }

        public void Draw()
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            Console.ForegroundColor = this.Color;
            Console.WriteLine(Label);
            Console.ForegroundColor = savedColor;
        }
    }
}

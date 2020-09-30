using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /**********************
     * This is a Graphic class which displays a sprite (in the form of a unicode symbol) on the screen.
     * It IS NOT a 2D Shape (does not have an area or perimeter for instance).  So we use the IDrawwable interface to 
     * say that indeed we can draw this class on a screen.
     * 
     **********************/
    public class Graphic : IDrawable
    {
        static private Dictionary<string, string> glyphSymbols = new Dictionary<string, string>()
        {
            {"Spades", "\u2660"},
            {"Diamonds", "\u2666"},
            {"Clubs", "\u2663"},
            {"Hearts", "\u2665"},
            {"Music", "♫" },

        };

        static public string[] GlyphNames
        {
            get
            {
                List<string> names = new List<string>(glyphSymbols.Keys);
                return names.ToArray();
            }
        }

        private string glyphSymbol;
        public string Name { get; }
        public ConsoleColor Color { get; set; }

        public Graphic(string glyphName, ConsoleColor color)
        {
            Color = color;
            if (glyphSymbols.ContainsKey(glyphName))
            {
                Name = glyphName;
                this.glyphSymbol = glyphSymbols[glyphName];
            }
            else
            {
                throw new ArgumentException($"Invalid glyph name: {glyphName}");
            }
        }
        public override string ToString()
        {
            return $"A {Color} Graphic of glyph '{Name}'";
        }

        public void Draw()
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            Console.ForegroundColor = this.Color;
            Console.WriteLine(glyphSymbol);
            Console.ForegroundColor = savedColor;
        }
    }
}

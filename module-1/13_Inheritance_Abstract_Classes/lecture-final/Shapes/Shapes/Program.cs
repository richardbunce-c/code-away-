using System;
using System.Collections.Generic;

namespace Shapes
{
    class Program
    {
        /****************** Polymorphism and Interfaces ********************
         * 
        ********************************************************************/

        /* *
         * First, Draw 2D Shapes.  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * 
         * Later, we are going to want to draw additional things, like Sprites and Labels.
         * Are these things shapes?  Do they have Area and Perimeter?
         * So let's make an IDrawable and change our collection to a List of IDrawable.
         * */
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ConsoleColor savedColor = Console.ForegroundColor;
            SetRandomColor();
            Console.WriteLine("███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗██╗");
            SetRandomColor();
            Console.WriteLine("██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝██║");
            SetRandomColor();
            Console.WriteLine("███████╗███████║███████║██████╔╝█████╗  ███████╗██║");
            SetRandomColor();
            Console.WriteLine("╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║╚═╝");
            SetRandomColor();
            Console.WriteLine("███████║██║  ██║██║  ██║██║     ███████╗███████║██╗");
            SetRandomColor();
            Console.WriteLine("╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝");
            Console.ForegroundColor = savedColor;
            DrawingManager manager = new DrawingManager();
            manager.Run();

            Console.WriteLine("Thanks for drawing with us!");
            Console.ReadKey();
        }

        static private void SetRandomColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            Random rand = new Random();
            int ix = rand.Next(1, colors.Length);
            ConsoleColor color = (ConsoleColor)colors.GetValue(ix);
            Console.ForegroundColor = color;
        }
    }
}

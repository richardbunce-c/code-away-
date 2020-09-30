using Shapes.Models;
using System;
using System.Collections.Generic;

namespace Shapes
{
    /****************** Polymorphism and Interfaces ********************
     * TODO 01 Define an IDrawable interface, which contains one method: Draw
     * 
    ********************************************************************/

    /**********************
    * TODO 05 Create a Text class that is IDrawable.  Implement the interface.
    * This is a Text class which displays a string on the screen.
    * It IS NOT a 2D Shape (does not have an area or perimeter for instance).  So we use the IDrawwable 
    * interface to say that indeed we can draw this class on a screen.
    * 
    **********************/

    class Program
    {

        /* *
         * First, Draw 2D Shapes.  Circle and Rectangle will do the trick, but one can imagine triangles and other polygons.
         * 
         * Later, we are going to want to draw additional things, like Sprites and Labels.
         * Are these things shapes?  Do they have Area and Perimeter?
         * So let's make an IDrawable and change our collection to a List of IDrawable.
         * */
        static void Main(string[] args)
        {
            Console.WriteLine("███████╗██╗  ██╗ █████╗ ██████╗ ███████╗███████╗██╗");
            Console.WriteLine("██╔════╝██║  ██║██╔══██╗██╔══██╗██╔════╝██╔════╝██║");
            Console.WriteLine("███████╗███████║███████║██████╔╝█████╗  ███████╗██║");
            Console.WriteLine("╚════██║██╔══██║██╔══██║██╔═══╝ ██╔══╝  ╚════██║╚═╝");
            Console.WriteLine("███████║██║  ██║██║  ██║██║     ███████╗███████║██╗");
            Console.WriteLine("╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝");



            DrawingManager manager = new DrawingManager();
            manager.Run();

            Console.WriteLine("Thanks for drawing with us!");
            Console.ReadKey();
        }
    }
}

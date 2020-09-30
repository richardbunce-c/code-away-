using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes.Models
{
    /**************************************************
    * Until now, we have been Drawing Shape2D objects (including anything that IS A Shape2D by inheritance).  But we
    * need to include other drawable things which are not 2D shapes, like sprites and lines.  So we defined an IDrawable 
    * interface to say what a class CAN DO.  
    * 
    **************************************************/

    // TODO 01 Which methods on the Shape2D class should NOT have an implementation?
    // TODO 02: And what does that do to the class?
    // TODO 03: And what happens when we try to derive from this class now?
    public class Shape2D : IDrawable
    {
        #region Properties
        public bool IsFilled { get; set; }

        public ConsoleColor Color { get; set; }

        virtual public int Area
        {
            get
            {
                return 0;
            }
        }

        virtual public int Perimeter
        {
            get
            {
                return 0;
            }
        }

        #endregion

        public Shape2D()
        {
            Color = ConsoleColor.White;
            IsFilled = false;
        }


        #region Methods

        virtual public void Draw() { }

        public override string ToString()
        {
            return $"A shape with Area={Area} and Perimeter={Perimeter}";
        }

        #endregion


        #region Helper Methods
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;

        protected void SetConsoleColor()
        {
            this.savedColor = Console.ForegroundColor;
            Console.ForegroundColor = Color;
        }

        protected void ResetConsoleColor()
        {
            Console.ForegroundColor = savedColor;
        }
        #endregion


    }
}

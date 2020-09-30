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
    * TODO 03 Update Shape2D to implement the IDrawable interface
    * 
    **************************************************/

    /// <summary>
    /// A two-dimensional shape that can be drawn on the screen
    /// </summary>
    public class Shape2D
    {
        #region Properties
        public bool IsFilled { get; set; }

        public ConsoleColor Color { get; set; }
        #endregion

        #region Fields
        // A place to save the current color for restoring after the draw
        private ConsoleColor savedColor = ConsoleColor.White;
        #endregion

        #region Constructors
        public Shape2D(ConsoleColor color, bool isFilled )
        {
            this.Color = color;
            this.IsFilled = isFilled;
        }
        #endregion


        #region Public Methods

        // This should be abstract later
        virtual public void Draw() { }
        
        // This should be abstract later
        virtual public int Area { get { return 0; } }

        // This should be abstract later
        virtual public int Perimeter { get { return 0; } }

        #endregion

        #region Helper Methods
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


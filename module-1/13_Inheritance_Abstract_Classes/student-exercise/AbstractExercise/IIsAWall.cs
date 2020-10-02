using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbstractExercise
{
    public interface IIsAWall
    {
        string Name { get; }
        string Color { get; }
        int Length { get; }
        int Height { get; }
        int GetArea();
    }
}

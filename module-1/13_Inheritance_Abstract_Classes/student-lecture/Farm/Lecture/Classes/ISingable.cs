using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Classes
{
    public interface ISingable
    {
        string Name { get; }

        string MakeSound();

        string MakeSoundTwice();

    }
}

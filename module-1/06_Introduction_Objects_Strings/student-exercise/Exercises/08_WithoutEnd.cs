﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {

        /*
         Given a string, return a version without the first and last char, so "Hello" yields "ell".
         The string length will be at least 2.
         WithoutEnd("Hello") → "ell"
         WithoutEnd("java") → "av"
         WithoutEnd("coding") → "odin"
         */
        public string WithoutEnd(string str)
        {
            string notFirstChar = str.Substring(1);
            string notLastChar = notFirstChar.Substring(0, notFirstChar.Length - 1);
            return notLastChar ;
        }
    }
}

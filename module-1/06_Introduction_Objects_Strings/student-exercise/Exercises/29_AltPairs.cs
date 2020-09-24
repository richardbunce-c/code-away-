using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string, return a string made of the chars at indexes 0,1, 4,5, 8,9 ... so "kittens" yields "kien".
         AltPairs("kitten") → "kien"
         AltPairs("Chocolate") → "Chole"
         AltPairs("CodingHorror") → "Congrr"
         */
        public string AltPairs(string str)
        {
            //Loop through the string, starting at 0, for every 4th character, and grab
            //the char at i and the char at i + 1
            string result = "";
            for (int i=0; i <str.Length; i= i +4)
            {
                if (i == str.Length - 1)
                {
                    result += str.Substring(i, 1);

                }
                else
                {


                    result += str.Substring(i, 2);
                }
                }
            return result;
            
        }
    }
}

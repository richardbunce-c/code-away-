using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        public List<string> No4LetterWords(string[] stringArray)
        {
            //    //Create a list to hold the string we want to return
            List<string> resultList = new List<string>();

//            //    //Loop through the array.
//            for (int i = 0; i < stringArray.Length; i++)
//            {
//                //        //Setup a variable pointing to the string we are interested in 
//                string s = stringArray[i];

//            //        //If the length of the string at i is != 4. add the string to the result list
//            if (s.Length != 4)
//            {
//                resultList.Add(s);
//            }
//            //Return the result list

//            return resultList;
//        }
            
//            return null;
//        }
//}
//}
foreach (string s in stringArray)
{
    if(s.Length !=4)
    {
        resultList.Add(s);
    }
}
return resultList;
}}}
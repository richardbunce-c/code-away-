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
         * Given the name of an animal, return the name of a group of that animal
         * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").
         *
         * The animal name should be case insensitive so "elephant", "Elephant", and
         * "ELEPHANT" should all return "herd".
         *
         * If the name of the animal is not found, null, or empty, return "unknown".
         *
         * Rhino -> Crash
         * Giraffe -> Tower
         * Elephant -> Herd
         * Lion -> Pride
         * Crow -> Murder
         * Pigeon -> Kit
         * Flamingo -> Pat
         * Deer -> Herd
         * Dog -> Pack
         * Crocodile -> Float
         *
         * AnimalGroupName("giraffe") → "Tower"
         * AnimalGroupName("") -> "unknown"
         * AnimalGroupName("walrus") -> "unknown"
         * AnimalGroupName("Rhino") -> "Crash"
         * AnimalGroupName("rhino") -> "Crash"
         * AnimalGroupName("elephants") -> "unknown"
         *
         */
        public string AnimalGroupName(string animalName)
        {
            Dictionary<string, string> animalDict = new Dictionary<string, string>();
            animalDict.Add("rhino", "Crash");
            animalDict.Add("giraffe", "Tower");
            animalDict.Add("elephant", "Herd");
            animalDict.Add("lion", "Pride");
            animalDict.Add("crow", "Murder");
            animalDict.Add("pigeon", "Kit");
            animalDict.Add("flamingo", "Pat");
            animalDict.Add("deer", "Herd");
            animalDict.Add("dog", "Pack");
            animalDict.Add("crocodile", "Float");

            animalName = animalName.ToLower();

            if (animalDict.ContainsKey(animalName))
            {
                return animalDict[animalName];
            }
            return "unknown";
        }
    }
}

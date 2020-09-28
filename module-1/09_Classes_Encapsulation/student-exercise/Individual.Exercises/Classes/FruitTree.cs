
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class FruitTree
    {
        public string TypeOfFruit { get; private set; }
        public int PiecesOfFruitLeft { get; private set; }

        public FruitTree(string typeOfFruit, int startingPiecesOfFruit)
        {
            PiecesOfFruitLeft = startingPiecesOfFruit;
            TypeOfFruit = typeOfFruit;
        }

        public bool PickFruit(int numberOfPiecesToRemove)
        {

            while (numberOfPiecesToRemove > 0 && PiecesOfFruitLeft > 0)
            {
                PiecesOfFruitLeft -= 1;
                numberOfPiecesToRemove -= 1;
            }

            if (numberOfPiecesToRemove == 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
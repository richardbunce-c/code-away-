using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Card
    {
        private Dictionary<int, string> cardNames = new Dictionary<int, string>()
        {
            {1, "Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" },
        };

        private Dictionary<string, string> suitNames = new Dictionary<string, string>()
        {
            {"H", "Hearts" },
            {"D", "Diamonds" },
            {"S", "Spades" },
            {"C", "Clubs" },
        };

        // Properties of the Card class
        public string Suit { get;  }

        // Derived from Suit
        public string SuitName
        {
            get
            {
                return suitNames[Suit];
            }
        }

        public int Value { get; }

        // "Ace", "Two", "Jack", etc
        public string ValueName
        {
            get
            {
                return cardNames[Value];
            }
        }

        public string CardTitle
        {
            get
            {
                return $"{ValueName} of {SuitName}";
            }
        }

        // Color is derived from suit
        public string Color
        {
            get
            {
                if (Suit == "H" || Suit == "D")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        public bool IsFaceUp { get; set; } = false;

        // Constructor
        public Card(string suit, int value)
        {
            // TODO: Check that the suit passed ni is valid (S, C, H, D) and value = from 1-13

            Suit = suit;
            Value = value;
        }


        // Methods

        public void Flip()
        {
            //if (IsFaceUp)
            //{
            //    IsFaceUp = false;
            //}
            //else
            //{
            //    IsFaceUp = true;
            //}
            IsFaceUp = !IsFaceUp;
        }

    }
}

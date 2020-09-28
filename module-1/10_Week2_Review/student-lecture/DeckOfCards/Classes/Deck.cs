using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        //Properties
        public int Count
        {
            get
            {
                return this.cards.Count;
            }
        }
        public Deck()
        {
            // Create the cards for the deck
            string[] suits = new string[] { "H", "D", "C", "S" };

            // Loop for every suit
            foreach(string suit in suits)
            {
                //Add a card for every value from 1 to 13
                for(int value = 0; value <=13; value++)
                {
                    Card card = new Card(suit, value);
                    cards.Add(card);
                }
            }
        }
   
    // Methods
    public Card Deal()
        {
            if (cards.Count>0)
            {
                Card card = this.cards[0];
                cards.RemoveAt(0);
                return card;
            }
            return null;
           
        }

    }
}

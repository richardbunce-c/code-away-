using DeckOfCards.Classes;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card symbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // TODO: Create a card game and start playing!
            Card card = new Card("H", 7);
            Console.WriteLine($"The card is {card.CardTitle} and its color is {card.Color}, and it {(card.IsFaceUp ? "is" : "is not")} face up.");

            card.Flip();
            Console.WriteLine($"The card is {card.CardTitle} and its color is {card.Color}, and it {(card.IsFaceUp ? "is" : "is not")} face up.");

            //Create a new deck, deal cards until the deck is empty
            Deck deck = new Deck();
            
            while (deck.Count>0)
            {
                Card dealtCard=deck.Deal();
                Console.WriteLine(dealtCard.CardTitle);
            }
            card = deck.Deal();
        }

        
    }
}

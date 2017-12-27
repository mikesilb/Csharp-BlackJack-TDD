using System;
using System.Collections.Generic;
using CardLibrary;

namespace DeckLibrary
{
   public class Deck
    {
        public Card[] theDeck = new Card[52];
        private Random randomNumbers;
        public int currentCard = 0;
        public Deck()
        {
            string[] rankList = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            string[] suitList = { "♦", "♣", "♠", "♥" };

            randomNumbers = new Random();
            for (int i = 0; i < theDeck.Length; i++)
            {
                theDeck[i] = new Card(suitList[i / 13], rankList[i % 13]);
            }


        }

        public void Shuffle()
        {
            for (int first = 0; first < theDeck.Length ; first++)
            {
                int second = randomNumbers.Next(52);

                Card temp = theDeck[first];
                theDeck[first] = theDeck[second];
                theDeck[second] = temp;
            }
        }

        public Card Deal()
        {
            return theDeck[currentCard++];   
        }

    }

}
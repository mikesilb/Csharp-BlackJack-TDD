using System;
using CardLibrary;
using DeckLibrary;
using HandLibrary;
using System.Collections.Generic;

namespace BlackJackTDD
{
    public class Blackjack
    {
        private Dictionary<string, Deck> gameDataDeck = new Dictionary<string, Deck>();
        public Dictionary<string, Hand> gameDataHand = new Dictionary<string, Hand>();
        public Dictionary<string, List<int>> gameDataListInt = new Dictionary<string, List<int>>();
        public Dictionary<string, string> gameDataString = new Dictionary<string, string>();

        public Blackjack()
        {
            Deck gameDeck = new Deck();
            gameDataDeck.Add("Game Deck", gameDeck);
            List<Card> playerHandList = new List<Card> { };
            List<Card> dealerHandList = new List<Card> { };
            Hand playerHand = new Hand(playerHandList);
            Hand dealerHand = new Hand(dealerHandList);
            gameDataHand.Add("Player Hand", playerHand);
            gameDataHand.Add("Dealer Hand", dealerHand);
            List<int> playerScore = new List<int> {  };
            List<int> dealerScore = new List<int> {  };
            gameDataListInt.Add("Player Score", playerScore);
            gameDataListInt.Add("Dealer Score", dealerScore);
            playerScore.Add(0);
            dealerScore.Add(0);
            gameDataString.Add("Win Lose or Draw", "");
            string computerBustOutput = "";
        }

        public Dictionary<string, Deck> GetGameDataDeck()
        {
            return gameDataDeck;
        }



        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

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
        private Dictionary<string, Hand> gameDataHand = new Dictionary<string, Hand>();
        private Dictionary<string, List<int>> gameDataListInt = new Dictionary<string, List<int>>();
        public Dictionary<string, string> gameDataString = new Dictionary<string, string>();
        public string computerBustOutput = "";
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
            List<int> playerScore = new List<int> { };
            List<int> dealerScore = new List<int> { };
            gameDataListInt.Add("Player Score", playerScore);
            gameDataListInt.Add("Dealer Score", dealerScore);
            playerScore.Add(0);
            dealerScore.Add(0);
            gameDataString.Add("Win Lose or Draw", "");
            gameDataDeck["Game Deck"].Shuffle();
        }

        public void InitialDeal()
        {
            gameDataHand["Player Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());
            gameDataHand["Player Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());

            foreach (var card in gameDataHand["Player Hand"].cardCollection)
            {
                Console.WriteLine($"Player was dealt {card.rank}{card.suit}");
            }
            gameDataListInt["Player Score"].Add(gameDataHand["Player Hand"].CalculateHand());
            Console.WriteLine($"Player score: {gameDataListInt["Player Score"][1]}");
            gameDataHand["Dealer Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());
            gameDataHand["Dealer Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());
            gameDataListInt["Dealer Score"].Add(gameDataHand["Dealer Hand"].CalculateHand());
        }

        public bool HitOrStandPrompt()
        {
            if (gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1] > 21)
            {
                Console.WriteLine("Bust! You lose...");
                gameDataString["Win Lose or Draw"] = "loss";
            }
            else
            {
                Console.WriteLine("Hit or stand (H/S):");
                string hitStand = Console.ReadLine().ToUpper();
                while (hitStand != "H" && hitStand != "S")
                { 
                    Console.WriteLine("This input is not accepted.  Please try again!");
                    Console.WriteLine("Hit or stand (H/S):");
                    hitStand = Console.ReadLine().ToUpper();
                } 

                if (hitStand == "S")
                {
                    Stand("Player");
                }
                else
                {
                    while (hitStand != "S" && gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1] < 21) 
                    {
                        Hit("Player");
                        if (gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1] > 21)
                        {
                            Console.WriteLine("Bust! You lose...");
                            gameDataString["Win Lose or Draw"] = "loss";
                        }
                        else
                        {
                            Console.WriteLine("Hit or stand (H/S):");
                            hitStand = Console.ReadLine().ToUpper();
                        }

                    }
                }
            }
            if (gameDataString["Win Lose or Draw"] == "loss")
            {
                return false;
            }
            return true;
        }

        public void Hit(string playerOrDealer)
        {
            
            if (playerOrDealer == "Player")
            {
                gameDataHand["Player Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());
                gameDataListInt["Player Score"].Add(gameDataHand["Player Hand"].CalculateHand()); 
                Console.WriteLine($"Player was dealt {gameDataHand["Player Hand"].cardCollection[gameDataHand["Player Hand"].cardCollection.Count - 1].rank}{gameDataHand["Player Hand"].cardCollection[gameDataHand["Player Hand"].cardCollection.Count - 1].suit}");
                Console.WriteLine($"Player score: {gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1]}");
            }
            else if (playerOrDealer == "Dealer")
            {
                gameDataHand["Dealer Hand"].cardCollection.Add(gameDataDeck["Game Deck"].Deal());
                gameDataListInt["Dealer Score"].Add(gameDataHand["Dealer Hand"].CalculateHand());
                Console.WriteLine($"Dealer was dealt {gameDataHand["Dealer Hand"].cardCollection[gameDataHand["Dealer Hand"].cardCollection.Count - 1].rank}{gameDataHand["Dealer Hand"].cardCollection[gameDataHand["Dealer Hand"].cardCollection.Count - 1].suit}");
                Console.WriteLine($"Dealer score: {gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1]}");
            }
        }

        public void Stand(string playerOrDealer)
        {
           if (playerOrDealer == "Player")
            {
                Console.WriteLine($"Player standing with a score of {gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1]}.");
            }
            else if (playerOrDealer == "Dealer")
            {
                Console.WriteLine($"Dealer standing with a score of {gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1]}.");
            }
        }

        public void DealerMoves()
        {
            foreach (var card in gameDataHand["Dealer Hand"].cardCollection)
            {
                Console.WriteLine($"Dealer was dealt {card.rank}{card.suit}");
            }
            Console.WriteLine($"Dealer score: {gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1]}");
            while (gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1] < 17)
            {
                Hit("Dealer");
                if (gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1] > 21)
                {
                    computerBustOutput = "Bust! You Win";
                    Console.WriteLine(computerBustOutput);
                    gameDataString["Win Lose or Draw"] = "win";
                }

            }
            if (gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1 ] <= 21)
            {
                Console.WriteLine("Dealer stands.\n");
                if (gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1] > gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1])
                {
                    Console.WriteLine("Dealer wins.");
                    gameDataString["Win Lose or Draw"] = "loss";
                }
                else if (gameDataListInt["Player Score"][gameDataListInt["Player Score"].Count - 1] > gameDataListInt["Dealer Score"][gameDataListInt["Dealer Score"].Count - 1])
                {
                    Console.WriteLine("Player wins.");
                    gameDataString["Win Lose or Draw"] = "win";
                }
                else
                {
                    Console.WriteLine("Tie game.");
                    gameDataString["Win Lose or Draw"] = "tie";
                }
            }
        }


        public Dictionary<string, Deck> GetGameDataDeck()
        {
            return gameDataDeck;
        }

        public Dictionary<string, Hand> GetGameDataHand()
        {
            return gameDataHand;
        }

        public Dictionary<string, List<int>> GetGameDataListInt()
        {
            return gameDataListInt;
        }

        public string GetComputerBustOutput()
        {
            return computerBustOutput;
        }


        public static void Main(string[] args)
        {
            Blackjack testBj = new Blackjack();
            testBj.InitialDeal();
            bool playerResult = testBj.HitOrStandPrompt();
            if (playerResult != false)
            {
                testBj.DealerMoves();
            }
        }

    }
}

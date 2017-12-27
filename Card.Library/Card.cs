using System;

namespace CardLibrary
{
    public class Card
    {
        public string suit { get; set; } 
        public string rank { get; set; }

        public Card(string newSuit, string newRank)
        {
            this.suit = newSuit;
            this.rank = newRank;
        }

        public string output()
        {
            return $"({suit}, {rank})";
        }
    }
}

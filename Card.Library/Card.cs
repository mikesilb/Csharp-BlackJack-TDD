using System;

namespace CardLibrary
{
    public class Card
    {
        private string suit;
        private string rank;

        public Card(string newSuit, string newRank)
        {
            this.suit = newSuit;
            this.rank = newRank;
        }

        public string GetSuit()
        {
            return this.suit;
        }

        public void SetSuit(string newSuit)
        {
            this.suit = newSuit;
        }

        public string GetRank()
        {
            return this.rank;
        }

        public string GetNonNumbersRank()
        {
            return this.rank;
        }

        public int GetNumbersRank()
        {
            return Int16.Parse(this.rank);
        }

        public void SetRank(string newRank)
        {
            this.rank = newRank;
        }

    }
}

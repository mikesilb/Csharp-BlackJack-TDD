using System;
using System.Collections.Generic;
using CardLibrary;
namespace HandLibrary
{
    public class Hand
    {
        public List<Card> cardCollection { get; set; }

        public Hand(List<Card> theCardCollection)
        {
            this.cardCollection = theCardCollection; 
        }

       
        public int CalculateHand()
       {
            int sum = 0; 
            foreach (var card in this.cardCollection)
            {
                int outcome;
                if (int.TryParse(card.rank, out outcome))
                {
                    sum += int.Parse(card.rank);
                }
                else if(card.rank != "A")
                {
                    sum += 10;
                }
                else if (sum <= 10)
                {
                    sum += 11;
                }
                else 
                {
                    sum += 1;
                }

            }

            return sum;

        }
    }
}

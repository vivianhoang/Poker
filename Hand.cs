using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Hand
    {
        public Card[] cards = new Card[5];

        public override string ToString()
        {
            string s = "";
            foreach (Card c in cards)
                s += c.ToString() + ", ";
            return s;
        }

        public HandType Evaluate()
        {
            // Sort cards for easier evaluation
            Array.Sort(cards);
            // Am I a flush?
            bool flush = IsFlush();
            if (flush == true)
                Console.WriteLine("I am a flush.");
            // Am I a straight?
            bool straight = IsStraight();
            if (straight == true)
                Console.WriteLine("I am a straight.");
            // Do I have pairs? Or more of a kind?
            int pairs = CountPairs();
            if (pairs != 0)
                Console.WriteLine("I have " + pairs + " pair(s).");
            else
                Console.WriteLine("I have no pairs.");
            //int mostOfAKind = MostOfAKind();

            return HandType.Flush;
        }

        private int CountPairs()
        {
            Dictionary<int, int> Pairs = new Dictionary<int, int>();

            for (int i = 0; i < cards.Length; i++) {
                if (Pairs.ContainsKey(cards[i].rank))
                {
                    Pairs[cards[i].rank] = Pairs[cards[i].rank] + 1;
                }
                else
                    Pairs[cards[i].rank] = 1;
            }

            int count = 0;
            foreach (KeyValuePair<int, int> entry in Pairs)
            {
                if (entry.Value == 2)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Are all cards in the hand the same suit
        /// </summary>
        private bool IsFlush()
        {
            // iterate through card array, 
            // checking each card's suit against 1st card
            char suit = cards[0].suit;
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i].suit != suit)
                {
                    Console.WriteLine("I am not a flush.");
                    return false;
                }
            }
            return true;
        }

        private bool IsStraight()
        {
            int rank = cards[0].rank;
            for (int i = 1; i < cards.Length; i++)
            {
                if (cards[i].rank != rank + 1)
                {
                    Console.WriteLine("I am not a straight.");
                    return false;
                }
                rank = cards[i].rank;
            }
            return true;
        }
    }
}

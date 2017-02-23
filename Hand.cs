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

            // Am I a straight?
            bool straight = IsStraight();

            // Do I have pairs?
            int pairs = CountPairs();

            // Do I have 3 or 4 of a kinds?
            int mostOfAKind = MostOfAKind();

            // Returning the type of hand the player has
            if (flush && straight)
            {
                Console.WriteLine("Straight Flush");
                return HandType.StraightFlush;
            }
            else if (mostOfAKind == 4)
            {
                Console.WriteLine("4 of a kind");
                return HandType.FourOfAKind;
            }
            else if (mostOfAKind == 3 && pairs == 1)
            {
                Console.WriteLine("Full House");
                return HandType.FullHouse;
            }
            else if (flush)
            {
                Console.WriteLine("Flush");
                return HandType.Flush;
            }
            else if (straight)
            {
                Console.WriteLine("Straight");
                return HandType.Straight;
            }
            else if (mostOfAKind == 3)
            {
                Console.WriteLine("3 of a kind");
                return HandType.ThreeOfAKind;
            }
            else if (pairs == 2)
            {
                Console.WriteLine("Two pairs");
                return HandType.TwoPair;
            }
            else if (pairs == 1)
            {
                Console.WriteLine("One pair");
                return HandType.Pair;
            }
            else 
                return HandType.HighCard;

        }

        //public Hand TieBreaker(Hand ht1, Hand ht2, int highest1, int highest2)
        //{

        //    return Hand (h1 or h2)
        //}

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
                    return false;
                }
                rank = cards[i].rank;
            }
            return true;
        }

        private int MostOfAKind()
        {
            Dictionary<int, int> AKinds = new Dictionary<int, int>();

            for (int i = 0; i < cards.Length; i++)
            {
                if (AKinds.ContainsKey(cards[i].rank))
                {
                    AKinds[cards[i].rank] = AKinds[cards[i].rank] + 1;
                }
                else
                    AKinds[cards[i].rank] = 1;
            }

            foreach (KeyValuePair<int, int> entry in AKinds)
            {
                if (entry.Value == 4)
                    return entry.Value;
                else if (entry.Value == 3)
                    return entry.Value;
            }
            return 0;
        }
    }
}

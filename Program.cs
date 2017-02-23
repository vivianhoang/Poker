using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get 5 cards
            Hand hand = Get5Cards();
            // Evaluate what kind of hand
            HandType ht1 = hand.Evaluate();
            int highest1 = hand.cards.Max().rank;
            //Console.WriteLine(ht1);
            //Console.WriteLine(highest1);

            // Get 5 other cards
            Hand hand2 = Get5Cards();
            // Evaluate type
            HandType ht2 = hand2.Evaluate();
            int highest2 = hand2.cards.Max().rank;
            //Console.WriteLine(ht2);
            //Console.WriteLine(highest2);


            // If types are different, better one wins
            if (ht1 > ht2)
                Console.WriteLine("Hand 1 is better");
            else if (ht1 < ht2)
                Console.WriteLine("Hand 2 is better");
            // If types are same, evaluate with a tie breaker

            Hand winner = TieBreaker(ht1, ht2, highest1, highest2);
            
            /*
            else if (highest1 > highest2)
            {
                Console.WriteLine("Hand 1 wins with " + hand.cards.Max() + ".");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Hand 2 wins with highest " + hand2.cards.Max() + ".");
                Console.ReadLine();
            }  */
        }

        static Hand Get5Cards()
        {
            Console.WriteLine("Please enter 5 cards, one per line");
            Hand hand = new Hand();
            for (int i = 0; i < 5; i++)
                hand.cards[i] = ReadCardFromConsole();
            Console.WriteLine("Confirming, your hand is: " + hand);
            return hand;
        }

        static Card ReadCardFromConsole()
        {
            Card c = new Card();
            // two characters, one is suit, one is rank
            // fill in card, and return it
            // blank line returns null, meaning done
            while (!c.IsValid())
            {
                string s = Console.ReadLine();
                if (s.Length != 2)
                    return null;
                c.SetFromChar(s[0]);
                c.SetFromChar(s[1]);
                if (!c.IsValid())
                {
                    Console.WriteLine("Invalid card, try again");
                    c = new Card();
                }
            }
            return c;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card : IComparable<Card>
    {
        public int rank;  // 2-14 (ace high)
        public char suit;  // c, s, h, or d

        public override string ToString()
        {
            return rank + " of " + suit;
        }

        public bool IsValid()
        {
            return rank != 0 && suit != '\0';
        }

        public void SetFromChar(char ch)
        {
            // case sensitive sucks
            ch = char.ToUpper(ch);
            // 2-9 are easy
            if (ch >= '2' && ch <= '9')
                rank = ch - '0';
            // t,j,q,k,a are random, so special case
            else if (ch == 'T')
                rank = 10;
            else if (ch == 'J')
                rank = 11;
            // TODO Q, K, A
            // everything else is a suit
            else if (ch == 'S' || ch == 'C' || ch == 'D' || ch == 'H')
                suit = ch;
        }

        public int CompareTo(Card other)
        {
            return this.rank - other.rank;
        }
    }


}

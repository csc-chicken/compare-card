using Cardgame;
using System;
using System.Collections.Generic;

namespace Cardgame
{
    class Person
    {
        public List<Card> handcard = new List<Card>();

    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck mydeck = new Deck();
            mydeck.shuffle();
            Person p1 = new Person();
            Person p2 = new Person();
            mydeck.getcard(p1.handcard, 5);
            mydeck.getcard(p2.handcard, 5);
            Console.WriteLine("player1");
            foreach (var i in p1.handcard) 
            {
                Console.WriteLine("{0} {1}", i.suit, i.rank);
            }
            Cardtype cardtype = new Cardtype();
            cardtype.cardChecked(p1);


         /*   Console.WriteLine("player2");
            foreach (var i in p2.handcard)
            {
                Console.WriteLine("{0} {1}", i.suit, i.rank);
            }
         */
            // Card mycard = new Card(Suit.Club,Rank.Ace);
            // Cardtype cardtype = new Cardtype();
            // cardtype.cardChecked(mycard);
            //mydeck.getcard();
            Console.WriteLine();
        }
    }
}

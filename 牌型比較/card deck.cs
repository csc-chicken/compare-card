using System;
using System.Collections.Generic;

namespace Cardgame
{
	class Card
	{
		public Suit suit;
		public Rank rank;
		private Card() { }
		public Card(Suit thatsuit, Rank thatrank)
		{
			suit = thatsuit;
			rank = thatrank;
		}

		public override string ToString()
		{
			return "The " + rank + " of " + suit + "s";
			//throw new System.NotImplementedException();
		}
	}



	class Deck
	{
		private Card[] cards;
		public int[] myshuffle = new int[52];
		private static int cardnow = 0;
		public Deck()
		{
			cards = new Card[52];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 13; j++)
					for (int suitVal = 0; suitVal < 4; suitVal++)
					{
						for (int rankVal = 1; rankVal < 14; rankVal++)
							cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
					}
			}

		}
		public void getcard(List<Card> card,int cardnum)
        {
			for(var i = cardnow; i < cardnow+cardnum; i++)
			{
				card.Add(cards[i]);
				
			}
			cardnow += cardnum;
			//Console.WriteLine(cards[1].suit);
        } 
		public void shuffle()
		{
			Card[] newDeck = new Card[52];
			bool[] assigned = new bool[52];
			Random point = new Random();
			for(int i = 0; i < 52; i++)
            {
				int cardpp = 0;
				bool foundcard = false;
                while (foundcard == false)
                {
					cardpp = point.Next(52);
					if (assigned[cardpp] == false)
						foundcard = true;
                }
				assigned[cardpp] = true;
				newDeck[cardpp] = cards[i];
            }
			newDeck.CopyTo(cards, 0);
			/*var r = new Random();
			int cardnumber = r.Next(0,)*/
			/*if (cardNum >= 0 && cardNum <= 51)
				return cards[cardNum];
			else
				throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
					"Value must be between 0 and 51"));
			//throw new System.NotImplementedException();*/
		}
	}

}

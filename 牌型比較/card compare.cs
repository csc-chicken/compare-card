using System;
using System.Collections.Generic;

namespace Cardgame 
{
	class Cardtype
	{

		
		public void cardChecked(Card mycard)
		{
			Console.WriteLine(mycard.ToString());
			
		}
		public void cardChecked(Person mycard)
		{
			//mycard.handcard[0].rank;
			Console.WriteLine("有沒有同花? :   {0}",classifySuit(mycard));
			Console.WriteLine("有沒有鐵支? :   {0}", Array.Exists(classifyRank(mycard), element => element == 4));
			Console.WriteLine("有沒有葫蘆? :   {0}", Array.Exists(classifyRank(mycard), element => element == 3)&&
													 Array.Exists(classifyRank(mycard), element => element == 2));
			Console.WriteLine("有沒有三條? :   {0}", Array.Exists(classifyRank(mycard), element => element == 3));
			/*foreach (var i in mycard.handcard)
			{
				Console.WriteLine("{0} {1}", i.suit, i.rank);
			}*/


		}
		private bool classifySuit(Person person) //統計花色出現的次數
        {
			int[] suitnum = new int[4] { 0, 0, 0, 0 };
			
			for(var i=0;i<person.handcard.Count;i++)
            {
				switch (person.handcard[i].suit)
				{
					case Suit.Club:
						suitnum[0]++;
						break;
					case Suit.Diamond:
						suitnum[1]++;
						break;
					case Suit.Heart:
						suitnum[2]++;
						break;
					case Suit.Spade:
						suitnum[3]++;
						break;

				}

            }
			return Array.Exists(suitnum, element => element == 5);

        }
		private int[] classifyRank(Person person) //統計數字出現次數
        {
			int[] ranknum = new int[14];
			for(var i=0 ; i <ranknum.Length; i++)
            {
				ranknum[i] = 0;
            }
			for (var i = 0; i < person.handcard.Count; i++)
            {
				ranknum[(int)person.handcard[i].rank]++;
            }
			return ranknum;

		}
		

        
		//private int 
		/*public int royalStraightFlush(Deck incards) {
		if(incards.cards.)
		}*/
			
	    

		
	}
}

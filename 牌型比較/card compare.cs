using System;
using System.Collections.Generic;

namespace Cardgame 
{
	public enum Status
    {
		ONE,
		TWO,
		TWOTWO,
		THREE,
		FLUSH,
		TONGHUA,
		HULU,
		TIGI,
		RFLUSH
    }

	class Cardtype
	{
		
		
		
		public void cardChecked(Card mycard)
		{
			Console.WriteLine(mycard.ToString());
			
		}
		public void cardChecked(Person mycard)
		{
			//數數字出現了幾次
			int[] thisrank = classifyRank(mycard);

			//把牌大小抓來排序
			int[] cardrank = new int[5];
			for (var i = 0; i < mycard.handcard.Count; i++)
			{
				cardrank[i] = (int)mycard.handcard[i].rank;
			}
			Array.Sort(cardrank);


			//找 2,3,4張一樣的
		    int[] rankcounter =new int[3];
			for(var card =0;card<thisrank.Length ;card++)
			{
                switch (thisrank[card])
				{
					case 2:
						rankcounter[0]++;
						mycard.bigcard = card;
						break;
					case 3:
						rankcounter[1]++;
						mycard.bigcard = card;
						break;
					case 4:
						rankcounter[2]++;
						mycard.bigcard = card;
						break;
					default:
						break;


                }
			}
			if (flushCheck(mycard,cardrank))
            {
				if (classifySuit(mycard)) 
				{ 
					mycard.status = Status.RFLUSH;
					mycard.bigcard = cardrank[cardrank.Length - 1];
				}
				else
				{
					mycard.status = Status.FLUSH;
					mycard.bigcard = cardrank[cardrank.Length - 1];
				}
            }
			else if (classifySuit(mycard))
            {
				mycard.status = Status.TONGHUA;
				mycard.bigcard = cardrank[cardrank.Length - 1];

			}
			else if (rankcounter[2] == 1){
				mycard.status = Status.TIGI;
            }
			else if(rankcounter[1] == 1)
			{
				if(rankcounter[0] == 1)
				{
					mycard.status = Status.HULU;
                }
                else
                {
					mycard.status = Status.THREE;
                }
			}
			else if (rankcounter[0] == 2)
            {
				mycard.status = Status.TWOTWO;
			}
			else if (rankcounter[0] == 1)
			{
				mycard.status = Status.TWO;
			}
			else
            {
				mycard.status = Status.ONE;
				mycard.bigcard = cardrank[cardrank.Length-1];
			}
			Console.WriteLine("你拿到 {0}", mycard.status);
			Console.WriteLine("最大張為 {0}", mycard.bigcard);

			//mycard.handcard[0].rank;
			/*	Console.WriteLine("有沒有順子? :   {0}",flushCheck(mycard));

				Console.WriteLine("有沒有同花? :   {0}",classifySuit(mycard));
				Console.WriteLine("有沒有鐵支? :   {0}", Array.Exists(classifyRank(mycard), element => element == 4));
				Console.WriteLine("有沒有葫蘆? :   {0}", Array.Exists(classifyRank(mycard), element => element == 3)&&
														 Array.Exists(classifyRank(mycard), element => element == 2));
				Console.WriteLine("有沒有三條? :   {0}", Array.Exists(classifyRank(mycard), element => element == 3) &&
														 !Array.Exists(classifyRank(mycard), element => element == 2));
			*/
			/*foreach (var i in mycard.handcard)
			{
				Console.WriteLine("{0} {1}", i.suit, i.rank);
			}*/


		}
		private bool flushCheck(Person person, int[] cardrank)
        {
			

			bool isflush = true;
			for(var i = 0;i<cardrank.Length-1;i++)
            {
                if (cardrank[i + 1] != cardrank[i] + 1)
                {
					isflush = false;
					break;
                } 
            }
			return isflush;
			/*Console.Write("sort: ");
			foreach(var i in cardrank)
			{
				Console.Write(i+" ");

			}
			Console.Write("\n");*/

			
			//Array.Copy((int)person.handcard,cardrank);
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

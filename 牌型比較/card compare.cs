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
			mycard.handcard.Sort();
			foreach (var i in mycard.handcard)
			{
				Console.WriteLine("{0} {1}", i.suit, i.rank);
			}
			;

		}
		//private int 
		/*public int royalStraightFlush(Deck incards) {
		if(incards.cards.)
		}*/
			
	    

		
	}
}

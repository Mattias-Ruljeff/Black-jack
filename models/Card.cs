using System;

namespace examination_3
{
    class Card
    {
        // Attributes ---------------------------------------------------
        public Suit Suit { get; }
        public Rank Rank { get; }
        public int Value => (int) Rank;
        
        /// <summary>
        /// Constructor for Card-class. 
        /// </summary>
        /// <param name="suit"> The suit from Suit.enum. </param>
        /// <param name="rank"> The rank from Rank.enum. </param>
        public Card(Suit suit, Rank rank)
        {
        Suit = Enum.IsDefined(typeof(Suit), suit) ? suit : throw new ArgumentException(nameof(suit));
        Rank = Enum.IsDefined(typeof(Rank), rank) ? rank : throw new ArgumentException(nameof(rank));;
        }

        /// <summary>
        /// Returns a string with the Suit and Value of the card.
        /// </summary>
        /// <returns> A string. </returns>
        public override string ToString()
        {
            return $"{(char)Suit}{(Value > 1 && Value < 11 ? Value.ToString() : Rank.ToString().Substring(0, 1))}";
        }
    }
 
}
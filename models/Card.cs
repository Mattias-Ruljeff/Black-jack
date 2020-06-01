using System;

namespace examination_3
{
    class Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public int Value => (int) Rank;
        
        public Card(Suit suit, Rank rank)
        {
        Suit = Enum.IsDefined(typeof(Suit), suit) ? suit : throw new ArgumentException(nameof(suit));
        Rank = Enum.IsDefined(typeof(Rank), rank) ? rank : throw new ArgumentException(nameof(rank));;
        }

        public override string ToString()
        {
            return $"{(char)Suit}{(Value > 1 && Value < 11 ? Value.ToString() : Rank.ToString().Substring(0, 1))}";
        }
    }
 
}
using System;
using System.Collections.Generic;

namespace examination_3
{
    class Deck
    {  
        // Properties
        public List<Card> _deckOfCards = new List<Card>();


        // Methods
        public void CreateDeck()
        {

            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))

            {
                foreach (var rank in (Rank[]) Enum.GetValues(typeof(Rank)))
                {
                    _deckOfCards.Add(new Card(suit, rank));
                }
            }
        }

    }
 
}
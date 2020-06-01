using System;
using System.Collections.Generic;

namespace examination_3
{
    class Deck
    {  
        // Properties
        public Stack<Card> _cards = new Stack<Card>();

        // Methods
        public void CreateDeck()
        {

            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))

            {
                foreach (var rank in (Rank[]) Enum.GetValues(typeof(Rank)))
                {
                    _cards.Push(new Card(suit, rank));
                }
            }
            ShuffleDeck();
        }

        private Stack<Card> ShuffleDeck()
        {
            var shuffle = _cards.ToArray();
            Random random = new Random();

            for (int i = 0; i < shuffle.Length; i++)
            {
                int randomNumber = random.Next(0, shuffle.Length);

                var tempvalue = shuffle[i];
                shuffle[i] = shuffle[randomNumber];
                shuffle[randomNumber] = tempvalue;
            }

            _cards.Clear();

            foreach (var card in shuffle)
            {
                _cards.Push(card);   
            }

            return _cards;
        }

        public Card TakeCardFromDeck(Deck deckOfCards)
        {
            Card card = deckOfCards._cards.Pop();
            return card;
        }
    }
}
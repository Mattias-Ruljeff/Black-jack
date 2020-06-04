using System;
using System.Collections.Generic;

namespace examination_3
{
    /// <summary>
    /// The deck of cars class.
    /// </summary>
    class Deck
    {  
        // Fields
        public Stack<Card> cards = new Stack<Card>();

        // Methods

        /// <summary>
        /// Creates a deck of cards.
        /// </summary>
        public void CreateDeck()
        {

            foreach (var suit in (Suit[]) Enum.GetValues(typeof(Suit)))
            {
                foreach (var rank in (Rank[]) Enum.GetValues(typeof(Rank)))
                {
                    cards.Push(new Card(suit, rank));
                }
            }
            foreach (var item in cards)
            {
                Console.WriteLine(item);
            }

            ShuffleDeck(cards);
        }

        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        /// <param name="deck"> A deck of cards. </param>
        /// <returns> The shuffleled deck of cards. </returns>
        public Stack<Card> ShuffleDeck(Stack<Card> deck)
        {
            var shuffle = deck.ToArray();
            Random random = new Random();

            for (int i = 0; i < shuffle.Length; i++)
            {
                int randomNumber = random.Next(0, shuffle.Length);

                var tempvalue = shuffle[i];
                shuffle[i] = shuffle[randomNumber];
                shuffle[randomNumber] = tempvalue;
            }

            deck.Clear();
            return deck;
        }

        /// <summary>
        /// "Pops" a card from the deck.
        /// </summary>
        /// <param name="deckOfCards"> The deck of cards from the GameTable.cs</param>
        /// <returns> A Card object. </returns>
        public Card TakeCardFromDeck(Deck deckOfCards)
        {
            Card card = deckOfCards.cards.Pop();
            return card;
        }
    }
}
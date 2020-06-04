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
            ShuffleDeck(cards);
        }

        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        /// <param name="deck"> A deck of cards. </param>
        /// <returns> The shuffleled deck of cards. </returns>
        public Stack<Card> ShuffleDeck(Stack<Card> deck)
        {
            var deckToShuffle = deck.ToArray();
            Random random = new Random();

            for (int i = 0; i < deckToShuffle.Length; i++)
            {
                int randomNumber = random.Next(0, deckToShuffle.Length);

                Card tempvalue = deckToShuffle[i];
                deckToShuffle[i] = deckToShuffle[randomNumber];
                deckToShuffle[randomNumber] = tempvalue;
            }
            deck.Clear();

            foreach (var item in deckToShuffle)
            {
                deck.Push(item);
            }
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
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
            Shuffle(cards);
        }

        /// <summary>
        /// Shuffles the deck of cards.
        /// </summary>
        /// <param name="cards"> A deck of cards. </param>
        /// <returns> The shuffleled deck of cards. </returns>
        public Stack<Card> Shuffle(Stack<Card> cards)
        {
            Card[] cardsToShuffle = cards.ToArray();
            Random random = new Random();

            for (int i = 0; i < cardsToShuffle.Length; i++)
            {
                int randomNumber = random.Next(0, cardsToShuffle.Length);

                Card tempvalue = cardsToShuffle[i];
                cardsToShuffle[i] = cardsToShuffle[randomNumber];
                cardsToShuffle[randomNumber] = tempvalue;
            }
            cards.Clear();

            foreach (var card in cardsToShuffle)
            {
                cards.Push(card);
            }
            return cards;
        }

        /// <summary>
        /// "Pops" a card from the deck.
        /// </summary>
        /// <param name="deckOfCards"> The deck of cards from the GameTable.cs</param>
        /// <returns> A Card object. </returns>
        public Card TakeCard(Deck deckOfCards)
        {
            Card card = deckOfCards.cards.Pop();
            return card;
        }

        public Card RemoveCard()
        {
            return cards.Pop();
        }
    }
}
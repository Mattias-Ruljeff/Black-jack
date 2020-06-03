using System.Collections.Generic;

namespace examination_3 {

    class Hand 
    {
        // Attributes --------------------------------------------
        private Stack<Card> _cardsOnHand = new Stack<Card>();
        public Stack<Card> CardsOnHand
        {
            get{ return _cardsOnHand;}
            set{ GetCard(value); }
        }
        // Methods -----------------------------------------------
        
        /// <summary>
        /// Gets a card from the deck of cards.
        /// </summary>
        /// <param name="card"> The deck of cards from GameTable.cs </param>
        public void GetCard(Stack<Card> card) 
        {
            var poppedCard = card.Pop();
            CardsOnHand.Push(poppedCard);
        }

    }



}
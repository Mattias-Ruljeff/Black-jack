using System;
using System.Collections.Generic;

namespace examination_3 {

    class Hand 
    {
        private Stack<Card> _cardsOnHand;
        public Stack<Card> CardsOnHand
        {
            get{ return _cardsOnHand;}
            set{ GetCard(value); }
        }

        public void GetCard(Stack<Card> card) 
        {
            var poppedCard = card.Pop();
            CardsOnHand.Push(poppedCard);
        }

    }



}
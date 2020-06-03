using System;
using System.Collections.Generic;

namespace examination_3
{
    class Player
    {
        // Attributes ---------------------------------------
        private Hand _hand = new Hand();
        private Stack<Card> _playerhand = new Stack<Card>();
        private int _handValue;
        protected String _name;
        protected int _stopvalue = new Random().Next(12,20);

        /// <summary>
        /// The name of the player.
        /// </summary>
        public String Name
        {
            get{ return _name;}
            set{ 
                    if(value == null)
                    {
                        throw new ArgumentException("Enter a name");
                    } 
                    else
                    {
                    _name = value;
                    }
                }
        }
        /// <summary>
        /// The cards in the players hand.
        /// </summary>
        public dynamic PlayerHand 
        {
            get { return _playerhand; }
        }
        /// <summary>
        /// The sum of the players hand.
        /// </summary>
        public int PlayerHandValue
        {
            get { return _handValue; }
            set {
                    if(value < 0)
                    {
                        throw new ArgumentException("Enter a number");
                    } 
                    else
                    {
                        _handValue = value;
                    }
                    }
        }

        // Methods --------------------------------------------------------
        /// <summary>
        /// Adds the "Popped" card from the deck of cards to the players hand.
        /// </summary>
        /// <param name="cardFromDeck"> A card the deck of cards. From GameTable.cs </param>
        public void GetCard(Card cardFromDeck) 
        {
            _playerhand.Push(cardFromDeck);
            TotalValueOfCards();
        }

        /// <summary>
        /// Generate a random number as the players stop-value.
        /// </summary>
        /// <value> Random int between 8 and 18. </value>
        public int StopValue {
            get{ return _stopvalue;}
            private set{
                Random random = new Random();
                _stopvalue = random.Next(8,19);
            }
        }
        /// <summary>
        /// Calculate the total value of the cards in the players hand.
        /// </summary>
        /// <returns> The calculated value of all the cards in the players hand. </returns>
        public void TotalValueOfCards()
        {
            int sum = 0;
            foreach (var card in PlayerHand)
            {
               sum += card.Value;
            }
            if (sum > 21)
            {
                PlayerHandValue = FindAceCardsAndChangeValue(sum);
            }
            else
            {
            PlayerHandValue = sum;
            }
        }

        /// <summary>
        /// If the total value of the sum is more than 21, search for "Ace" cards and
        /// change the value of the card fom 14 to 1.
        /// </summary>
        /// <param name="sum"> The calculated value of all the cards in the players hand. </param>
        /// <returns></returns>
        private int FindAceCardsAndChangeValue(int sum)
        {
            foreach(Card card in PlayerHand)
            {
                if(card.Rank == Rank.Ace)
                {
                    sum -= 13;
                }
            }
            return sum;
        }

        /// <summary>
        /// Constructor for Player-class.
        /// </summary>
        /// <param name="name"> A string representing the name of the player. </param>
        public Player(String name)
        {
            Name = name;
        }
    }
 
}
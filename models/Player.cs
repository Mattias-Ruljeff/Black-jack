using System;
using System.Collections.Generic;

namespace examination_3
{
    class Player
    {
        private Hand _hand = new Hand();
        private Stack<Card> _playerhand = new Stack<Card>();
        private int _playerHandValue;
        protected String _name;
        protected int _stopvalue = new Random().Next(12,20);

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

        public dynamic PlayerHand 
        {
            get { return _playerhand; }
        }
        public int PlayerHandValue
        {
            get { return TotalValueOfCards(); }
        }

        public void GetCard(Card cardFromDeck) 
        {
            _playerhand.Push(cardFromDeck);
        }


        public int StopValue {
            get{ return _stopvalue;}
            private set{
                Random random = new Random();
                _stopvalue = random.Next(8,19);
            }
        }
        public int TotalValueOfCards()
        {
            int sum = 0;
            foreach (var card in _playerhand)
            {
               sum += card.Value;
            }
            Console.WriteLine(sum);
            return sum;
        }
        public Player(String name)
        {
            Name = name;
        }
    }
 
}
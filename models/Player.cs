using System;
using System.Collections.Generic;

namespace examination_3
{
    public class Player
    {

        protected String _name;
        private List<Card> _hand = new List<Card>();
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
        public dynamic Hand { get{ return _hand; }
        }
        
        protected int StopValue {
            get{ return _stopvalue;}
            private set{
                Random random = new Random();
                _stopvalue = random.Next(8,19);
            }
        }
        public Player(String name)
        {
            Name = name;
        }
    }
 
}
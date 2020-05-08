using System;

namespace examination_3
{
    class Player
    {

        protected String _name;
        protected String[] _hand;
        protected int _stopvalue;

        public String Name {
            get{ return _name;}
            set{ 
                if(value != null)
                {
                    _name = value;
                }
                    throw new ArgumentException("Enter a name");
                }
        }
        public String[] Hand {
            get{ return _hand;}
            set{ 
                if(value != null)
                {
                    _hand = value;
                }
                    throw new ArgumentException("Cannot set hand to null");
                }
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

        }
    }
 
}
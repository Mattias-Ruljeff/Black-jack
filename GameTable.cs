using System;
using System.Collections.Generic;

namespace examination_3 {

    public class GameTable {
        // Properties
        private List<Card> _throwPile;
        private Deck _deck = new Deck();
        private int _numberOfPlayers;

        public int NumberOfPlayers
        {
            get{return _numberOfPlayers;}
            set
            { 
                if(value > 0) {
                _numberOfPlayers = value;
                }
                else if(value > 100)
                {
                    throw new ArgumentOutOfRangeException("Maximum number of players is 100");
                }else 
                {
                throw new ArgumentOutOfRangeException("Number must be greater than 0");
                }
            }
        }

        // Constructor

        public GameTable(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            StartGame();
        }

        // Methods
        public void StartGame() 
        {
            List<Player> _playersPlaying = new List<Player>();
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                _playersPlaying.Add(new Player($"Player {i + 1}"));
            }
            _playersPlaying.Add(new Dealer("Dealer"));

            _deck.CreateDeck();

            // foreach (var item in _playersPlaying)
            // {
            //     Console.WriteLine(item._stopvalue);
            // }

            PrintResult(_playersPlaying);
        }
        
        public void PrintResult(List<Player> playersPlaying) 
        {
            playersPlaying.ForEach((player) => System.Console.WriteLine(player.Name));
        }

        
    }

}
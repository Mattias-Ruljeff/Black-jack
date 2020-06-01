using System;
using System.Collections.Generic;

namespace examination_3 {

    class GameTable {
        // Properties
        private List<Card> _throwPile;
        private Deck _deck = new Deck();
        private List<Player> _playersPlaying = new List<Player>();

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

        // Adding the players and the dealer with one card each.
        public void StartGame() 
        {
            _deck.CreateDeck();
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                var newPlayer = new Player($"Player {i + 1}");
                var card = _deck._cards.Pop();
                newPlayer.GetCard(card);
                _playersPlaying.Add(newPlayer);
            }
            var dealer = new Dealer();
            var dealerCard = _deck._cards.Pop();
            dealer.GetCard(dealerCard);

            _playersPlaying.Add(dealer);

            StartPlayRound();
        }

        private void StartPlayRound ()
        {
            foreach (var player in _playersPlaying)
            {
                do
                {
                    Card card = _deck.TakeCardFromDeck(_deck);
                    player.GetCard(card);
                    Console.WriteLine(player.Name);
                    Console.WriteLine(player.StopValue);
                } while (player.PlayerHandValue < player.StopValue );

                if (player.PlayerHandValue > 21) 
                {
                    Console.WriteLine("Player lost");
                }
                if (player.PlayerHandValue < 21) 
                {
                    Console.WriteLine("Player won!");
                }
            }

        }
        private void PrintResult(List<Player> playersPlaying) 
        {
            playersPlaying.ForEach((player) => Console.WriteLine($"{player.Name} {player.StopValue}"));
        }

        
    }

}
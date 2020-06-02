using System;
using System.Collections.Generic;

namespace examination_3 {

    class GameTable {
        // Properties ---------------------------------------------------------
        private Stack<Card> _throwPile = new Stack<Card>();
        private Deck _deck = new Deck();
        private List<Player> _playersPlaying = new List<Player>();
        private Dealer dealer = new Dealer();
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

        // Methods ----------------------------------------------------

        // Adding the players and the dealer with one card each.
        public void StartGame() 
        {
            _deck.CreateDeck();
            for (int i = 0; i < _numberOfPlayers; i++)
            {
                var newPlayer = new Player($"Player {i + 1}");
                var card = _deck.cards.Pop();
                newPlayer.GetCard(card);
                _playersPlaying.Add(newPlayer);
            }
            var dealerCard = _deck.cards.Pop();
            dealer.GetCard(dealerCard);

            StartPlayRound();
        }

        private void StartPlayRound ()
        {
            foreach (var player in _playersPlaying)
            {
                dealCards(player);

                // Player gets more than 21 and looses.
                if (player.PlayerHandValue > 21) 
                {
                    PrintGameResultWithoutDealer(false, player, dealer);
                }

                // Player gets 21 and wins.
                if(player.PlayerHandValue == 21)
                {
                    PrintGameResultWithoutDealer(true, player, dealer);
                }

                // Player gets 5 cards and wins.
                if(player.PlayerHand.Count == 5)
                {
                    PrintGameResultWithoutDealer(true, player, dealer);
                }

                if (player.PlayerHandValue < 21) 
                {
                    dealCards(dealer);
                    int playerScore = player.PlayerHandValue;
                    int dealerScore = dealer.PlayerHandValue;
                    if(dealerScore == 21)
                    {
                        PrintGameResultWithDealer(false, player, dealer );
                    }
                    else if(dealerScore < 21)
                    {  
                        if(playerScore < dealerScore)
                        {
                            PrintGameResultWithDealer(false, player, dealer);
                        }
                        if(playerScore == dealerScore)
                        {
                            PrintGameResultWithDealer(false, player, dealer);
                        }
                        if(playerScore > dealerScore)
                        {
                            PrintGameResultWithDealer(true, player, dealer );
                        }

                    } else
                    {
                        PrintGameResultWithDealer(true, player, dealer);
                    }
                }
                dealer.PlayerHandValue = 0;
                Console.WriteLine();
                emptyPlayerHand(player);
                emptyPlayerHand(dealer);
            }

        }
        private void PrintGameResultWithoutDealer(bool ifPlayerWon, Player player, Player dealer)
        {
            Console.Write($"{player.Name} cards: ");
            PrintCardInConsole(player);
            Console.Write(
                player.PlayerHandValue <= 21 ?
                $" sum: ({player.PlayerHandValue}) {player.StopValue}" :
                $" sum: ({player.PlayerHandValue}) {player.StopValue}, BUSTED!");

            Console.WriteLine();
            Console.WriteLine($"{dealer.Name} cards:  -");
            Console.WriteLine(ifPlayerWon == true ? $"{player.Name} won!" : $"{dealer.Name} won!");

        }
        private void PrintGameResultWithDealer(bool ifPlayerWon, Player player, Player dealer)
        {
            Console.Write($"{player.Name} cards: ");
            PrintCardInConsole(player);
            Console.WriteLine(
            player.PlayerHandValue <= 21 ? $" sum: ({player.PlayerHandValue}){player.StopValue}" : $" sum: ({player.PlayerHandValue}) {player.StopValue}, BUSTED!");

            Console.Write($"{dealer.Name} cards: ");
            PrintCardInConsole(dealer);
            Console.WriteLine(
            dealer.PlayerHandValue <= 21 ? $" sum: ({dealer.PlayerHandValue}){dealer.StopValue}" : $" sum: ({dealer.PlayerHandValue}) {dealer.StopValue}, BUSTED!");

            Console.WriteLine(ifPlayerWon == true ? $"{player.Name} won!" : $"{dealer.Name} won!");

        }
        private void PrintCardInConsole(Player player)
        {
            foreach (var playerCard in player.PlayerHand)
                {
                    Console.Write($"{playerCard} ");
                }
        }

        private void dealCards(Player player)
        {
            Card card;
            do{
                
                if(_deck.cards.Count < 1)
                {
                    foreach (var deckCard in _throwPile)
                    {
                        _deck.cards.Push(deckCard);
                    }
                    _throwPile.Clear();
                    _deck.ShuffleDeck(_deck.cards);
                }
                card = _deck.TakeCardFromDeck(_deck);
                Console.WriteLine($"{card} kortet som ges till {player.Name}");
                player.GetCard(card);
                
            }
            while(player.PlayerHandValue < player.StopValue); 
        }

        private void emptyPlayerHand(Player player) 
        {
            foreach (var playerCard in player.PlayerHand)
            {
                _throwPile.Push(playerCard);
            }
            player.PlayerHand.Clear();
        }
        
    }

}
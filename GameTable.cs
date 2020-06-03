using System;
using System.Collections.Generic;

namespace examination_3 {
    /// <summary>
    /// GameTable-class. 
    /// </summary>
    class GameTable {
        // Fields ---------------------------------------------------------
        private Stack<Card> _throwPile = new Stack<Card>();
        private Deck _deck = new Deck();
        private List<Player> _playersPlaying = new List<Player>();
        private Dealer dealer = new Dealer();
        private int _numberOfPlayers;

        // Properties ------------------------------------------------------

        /// <summary>
        /// Sets the number of players. Minimun players is 1, maximum is 30.
        /// </summary>
        public int NumberOfPlayers
        {
            get{return _numberOfPlayers;}
            set
            { 
                if(value > 0 && value < 30) {
                _numberOfPlayers = value;
                }
                else if(value > 30)
                {
                    throw new ArgumentOutOfRangeException("Maximum number of players is 100");
                }else 
                {
                throw new ArgumentOutOfRangeException("Number must be greater than 0");
                }
            }
        }

        // Constructor ------------------------------------------------------------

        /// <summary>
        /// The starting point of GameTable.cs.
        /// </summary>
        /// <param name="numberOfPlayers"> The number of players playing. </param>
        public GameTable(int numberOfPlayers)
        {
            NumberOfPlayers = numberOfPlayers;
            StartGame();
        }

        // Methods ----------------------------------------------------------------

        /// <summary>
        /// Adding the players and the dealer to the game with one card each.
        /// </summary>
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

        /// <summary>
        /// Starts the game with every player against the dealer, start dealing to player.
        /// If the player does´n get 21 or more, the dealer get cards.
        /// </summary>
        private void StartPlayRound ()
        {
            foreach (var player in _playersPlaying)
            {
                DealCardsToPlayer(player);

                // Player gets more than 21 and loose.
                if (player.PlayerHandValue > 21) 
                {
                    PrintGameRoundResultWithoutDealer(false, player, dealer);
                    EmptyPlayerHand(player);

                    continue;
                }

                // Player gets 21 and wins.
                if(player.PlayerHandValue == 21)
                {
                    PrintGameRoundResultWithoutDealer(true, player, dealer);
                    EmptyPlayerHand(player);

                    continue;
                }

                // Player gets 5 cards and wins.
                if(player.PlayerHand.Count == 5)
                {
                    PrintGameRoundResultWithoutDealer(true, player, dealer);
                    EmptyPlayerHand(player);
                    continue;
                }

                if (player.PlayerHandValue < 21) 
                {
                    DealCardsToPlayer(dealer);
                    int playerScore = player.PlayerHandValue;
                    int dealerScore = dealer.PlayerHandValue;
                    if(dealerScore == 21)
                    {
                        PrintGameRoundResultWithDealer(false, player, dealer );
                    }
                    else if(dealerScore < 21)
                    {  
                        if(playerScore < dealerScore)
                        {
                            PrintGameRoundResultWithDealer(false, player, dealer);
                        }
                        if(playerScore == dealerScore)
                        {
                            PrintGameRoundResultWithDealer(false, player, dealer);
                        }
                        if(playerScore > dealerScore)
                        {
                            PrintGameRoundResultWithDealer(true, player, dealer );
                        }

                    } else
                    {
                        PrintGameRoundResultWithDealer(true, player, dealer);
                    }
                }
                dealer.PlayerHandValue = 0;
                Console.WriteLine();
                EmptyPlayerHand(player);
                EmptyPlayerHand(dealer);
            }

        }
        /// <summary>
        /// Prints the results of a round with a player, dealer does not get cards.
        /// </summary>
        /// <param name="ifPlayerWon"> Bool value, if the player won the round or not</param>
        /// <param name="player"> Player Object. </param>
        /// <param name="dealer"> Dealer Object. </param>
        private void PrintGameRoundResultWithoutDealer(bool ifPlayerWon, Player player, Dealer dealer)
        {
            Console.Write($"{player.Name} cards: ");

            PrintPlayerCardInConsole(player);

            Console.Write(player.PlayerHandValue <= 21 ?
                $" sum: ({player.PlayerHandValue})" :
                $" sum: ({player.PlayerHandValue}), BUSTED!");

            Console.WriteLine();
            Console.WriteLine($"{dealer.Name} cards:  -");
            Console.WriteLine(ifPlayerWon == true ? $"{player.Name} won!" : $"{dealer.Name} won!");
            Console.WriteLine();

        }
        /// <summary>
        /// Prints the results of a round with a player and dealer.
        /// </summary>
        /// <param name="ifPlayerWon"> Bool value, if the player won the round or not</param>
        /// <param name="player"> Player Object. </param>
        /// <param name="dealer"> Dealer Object. </param>
        private void PrintGameRoundResultWithDealer(bool ifPlayerWon, Player player, Dealer dealer)
        {
            Console.Write($"{player.Name} cards: ");

            PrintPlayerCardInConsole(player);

            Console.WriteLine(player.PlayerHandValue <= 21 ?
            $" sum: ({player.PlayerHandValue})" :
            $" sum: ({player.PlayerHandValue}), BUSTED!");

            Console.Write($"{dealer.Name} cards: ");

            PrintPlayerCardInConsole(dealer);

            Console.WriteLine(dealer.PlayerHandValue <= 21 ?
            $" sum: ({dealer.PlayerHandValue})" :
            $" sum: ({dealer.PlayerHandValue}), BUSTED!");

            Console.WriteLine(ifPlayerWon == true ? $"{player.Name} won!" : $"{dealer.Name} won!");

        }
        /// <summary>
        /// Prints the players card in the console beside the name of the player.
        /// </summary>
        /// <param name="player"> Player/Dealer Object</param>
        private void PrintPlayerCardInConsole(Player player)
        {
            foreach (var playerCard in player.PlayerHand)
                {
                    Console.Write($"{playerCard} ");
                }
        }
        /// <summary>
        /// Deals the player cards.
        /// If the deck is empty, the _throwpile is emptied and moved to the deck.
        /// The deck get shuffled.
        /// </summary>
        /// <param name="player"> A Player/Dealer Object</param>
        private void DealCardsToPlayer(Player player)
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
                player.GetCard(card);
            }
            while(player.PlayerHandValue < player.StopValue); 
        }
        /// <summary>
        /// Removes all the cards from the players hand and are added to the _throwpile.
        /// </summary>
        /// <param name="player"></param>
        private void EmptyPlayerHand(Player player) 
        {
            foreach (var playerCard in player.PlayerHand)
            {
                _throwPile.Push(playerCard);
            }
            player.PlayerHand.Clear();
        }
        
    }

}
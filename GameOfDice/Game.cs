using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace GameOfDice
{
    class Game
    {
        private readonly int[] _playerOrderArray;
        private readonly int _targetPoints;
        private bool[] _playerGameCompletedStatusArray;
        private bool[] _playerToBePenalizedStatusArray;
        private int _remainingPlayers;
        private int[] _playerPointsArray;
        // Index 0 corresponds to 1st rank player number
        private int[] _playersOrderedByRankArray;
        // Index 0 corresponds to 1st player's rank
        private int[] _playerRankArray;
        public Game(int totalPlayers, int targetPoints)
        {
            _playerOrderArray = Utils.GenerateOrder(totalPlayers);
            _playerGameCompletedStatusArray = new bool[totalPlayers];
            _playerToBePenalizedStatusArray = new bool[totalPlayers];
            _targetPoints = targetPoints;
            _remainingPlayers = totalPlayers;
            _playerPointsArray = new int[totalPlayers];
            _playerRankArray = Utils.Get1ToNArray(totalPlayers);
            _playersOrderedByRankArray = Utils.Get1ToNArray(totalPlayers);
        }

        private int GetDiceValue()
        {
            var rand = new Random();
            return rand.Next(1, 7);
        }
        internal bool IsGameCompleted()
        {
            return _remainingPlayers == 0;
        }

        internal void DecreaseRemainingPlayers()
        {
            _remainingPlayers--;
        }

        private bool IsPlayerGameCompleted(int playerNumber)
        {
            return _playerGameCompletedStatusArray[playerNumber - 1];
        }
        private void SetPlayerGameStatusCompleted(int playerNumber)
        {
            _playerGameCompletedStatusArray[playerNumber - 1] = true;
        }
        private bool CheckIfPlayerNeedToBePenalised(int playerNumber, int diceValue)
        {
            bool isPenalized = _playerToBePenalizedStatusArray[playerNumber - 1] && diceValue == 1;
            _playerToBePenalizedStatusArray[playerNumber - 1] = diceValue == 1;
            return isPenalized;
        }
        private bool CheckIfPlayerReachedTarget(int playerNumber)
        {
            return _playerPointsArray[playerNumber - 1] >= _targetPoints;
        }
        private void UpdatePlayerPoints(int playerNumber, int points)
        {
            _playerPointsArray[playerNumber - 1] += points;
        }
        private int GetPlayerCount()
        {
            return _playerOrderArray.Length;
        }
        private void UpdatePlayerRankArraysAfterDiceRoll(int playerNumber)
        {
            int currentRank;
            int currentPlayerPoints = _playerPointsArray[playerNumber - 1];
            while (true)
            {
                currentRank = _playerRankArray[playerNumber - 1];
                if (currentRank == 1)
                {
                    // break if already top ranker
                    break;
                }
                int aboveRankerPlayerNumber = _playersOrderedByRankArray[currentRank - 2];
                int aboveRankerPoints = _playerPointsArray[aboveRankerPlayerNumber - 1];
                if (aboveRankerPoints < currentPlayerPoints)
                {
                    // decrease rank of current player
                    _playerRankArray[playerNumber - 1] = _playerRankArray[playerNumber - 1] - 1;
                    // increase rank of above ranker to current
                    _playerRankArray[aboveRankerPlayerNumber - 1] = _playerRankArray[aboveRankerPlayerNumber - 1] + 1;
                    // Swap positions of both these players in ordered by rank array
                    int temp = _playersOrderedByRankArray[currentRank - 1];
                    _playersOrderedByRankArray[currentRank - 1] = _playersOrderedByRankArray[currentRank - 2];
                    _playersOrderedByRankArray[currentRank - 2] = temp;
                }
                else
                {
                    // Break if no more player with less points above.
                    break;
                }
            }
        }
        private void PrintRankTable()
        {
            int totalPlayers = _playerOrderArray.Length;
            Console.WriteLine();
            Console.Write("Player: ");
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.Write($"  {i + 1}  ");
            }
            Console.WriteLine();
            Console.Write("Rank:   ");
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.Write($"  {_playerRankArray[i]}  ");
            }
            Console.WriteLine();
            Console.Write("Points: ");
            for (int i = 0; i < totalPlayers; i++)
            {
                Console.Write($"  {_playerPointsArray[i]}  ");
            }
            Console.WriteLine();
        }
        internal static int GetNextPlayer(int i, int playerCount)
        {
            return (i + 1) % playerCount;
        }
        internal static bool GiveAnotherChance(int diceValue)
        {
            return diceValue == 6;
        }
        public void StartGame()
        {
            int playerCount = GetPlayerCount();
            for (int i = 0; i < playerCount;)
            {
                int playerNumber = _playerOrderArray[i];
                if (IsGameCompleted())
                {
                    Console.WriteLine("Game over.");
                    break;
                }
                if (IsPlayerGameCompleted(playerNumber))
                {
                    i = GetNextPlayer(i, playerCount);
                    continue;
                }
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(
                    $"Player-{playerNumber} its your turn (press any key to roll the dice)."
                );
                Console.ReadKey();
                int diceValue = GetDiceValue();
                Console.WriteLine($"Dice Value: {diceValue}");
                UpdatePlayerPoints(playerNumber, diceValue);
                UpdatePlayerRankArraysAfterDiceRoll(playerNumber);
                PrintRankTable();
                if (CheckIfPlayerNeedToBePenalised(playerNumber, diceValue))
                {
                    Console.WriteLine("Your are penalized for rolling 1 twice consecutively.");
                }
                if (CheckIfPlayerReachedTarget(playerNumber))
                {
                    SetPlayerGameStatusCompleted(playerNumber);
                    Console.WriteLine("Congratulations! Your have completed the game.");
                    DecreaseRemainingPlayers();
                }
                if (!GiveAnotherChance(diceValue))
                {
                    i = i = GetNextPlayer(i, playerCount);
                }
            }
        }
    }
}

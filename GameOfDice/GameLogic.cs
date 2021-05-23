using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace GameOfDice
{
    class GameLogic
    {
        internal static int GetDiceValue()
        {
            var rand = new Random();
            return rand.Next(1, 7);
        }
        internal static bool CheckIfPlayerReachedTarget(GameModel game, PlayerModel player)
        {
            return player.Points >= game.TargetPoints;
        }
        internal static void UpdatePlayerRankArraysAfterDiceRoll(GameModel game, PlayerModel currentPlayer)
        {
            // Continuously compare score with higher rank players to adjust rankings of current player
            while (true)
            {
                if (currentPlayer.Rank == 1)
                {
                    // Break if already top ranker
                    break;
                }
                PlayerModel higherRankPlayer = game.GetPlayerByRank(currentPlayer.Rank - 1);
                // Compare score with i-1 rank player and swap ranks if higher score
                if (higherRankPlayer.Points < currentPlayer.Points)
                {
                    game.SwapPositions(currentPlayer, higherRankPlayer);
                }
                else
                {
                    // Break if no more player with less points above.
                    break;
                }
            }
        }
        internal static void PrintRankTable(GameModel game)
        {
            Console.WriteLine();
            Console.Write("Player: ");
            foreach (var player in game.Players)
            {
                Console.Write($"  {player.Number}  ");
            }
            Console.WriteLine();
            Console.Write("Rank:   ");
            foreach (var player in game.Players)
            {
                Console.Write($"  {player.Rank}  ");
            }
            Console.WriteLine();
            Console.Write("Points: ");
            foreach (var player in game.Players)
            {
                Console.Write($"  {player.Points}  ");
            }
            Console.WriteLine();
        }
        internal static int GetNextPlayerIndex(int i, int playerCount)
        {
            return (i + 1) % playerCount;
        }
        internal static bool GiveAnotherChance(int diceValue)
        {
            return diceValue == 6;
        }
        public void StartGame(int totalPlayers, int targetPoints)
        {
            GameModel game = new GameModel(totalPlayers, targetPoints);
            game.InitializePlayers();
            int index = 0;
            while (!game.IsCompleted())
            {
                PlayerModel currentPlayer = game.GetCurrentPlayer(index);
                if (currentPlayer.IsGameComplete)
                {
                    index = GetNextPlayerIndex(index, game.PlayersCount);
                    continue;
                }
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(
                    $"Player-{currentPlayer.Number} its your turn (press any key to roll the dice)."
                );
                Console.ReadKey();
                int diceValue = GetDiceValue();
                Console.WriteLine($"You scored {diceValue} points.");
                currentPlayer.UpdatePoints(diceValue);
                UpdatePlayerRankArraysAfterDiceRoll(game, currentPlayer);
                PrintRankTable(game);
                if (currentPlayer.ShouldPenalize(diceValue))
                {
                    Console.WriteLine("Your are penalized for rolling 1 twice consecutively.");
                }
                currentPlayer.UpdatePreviousRoll1(diceValue);
                if (CheckIfPlayerReachedTarget(game, currentPlayer))
                {
                    currentPlayer.CompleteGame();
                    game.DecreaseRemainingPlayers();
                    Console.WriteLine("Congratulations! Your have completed the game.");
                }
                if (!GiveAnotherChance(diceValue))
                {
                    index = GetNextPlayerIndex(index, game.PlayersCount);
                }
            }
            Console.WriteLine("Game over.");
        }
    }
}

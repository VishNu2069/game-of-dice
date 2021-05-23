using System;

namespace GameOfDice
{
    public class GameModel
    {
        public GameModel(int totalPlayers, int targetPoints)
        {
            Order = Utils.GenerateOrder(totalPlayers);
            PlayerNumberByRank = Utils.Get1ToNArray (totalPlayers);
            TargetPoints = targetPoints;
            RemainingPlayers = totalPlayers;
            Players = new PlayerModel[totalPlayers];
            PlayersCount = totalPlayers;
        }
        public int[] Order { private set; get; }
        public int TargetPoints { private set; get; }
        public int PlayersCount { private set; get; }
        public int RemainingPlayers { set; get; }
        public int[] PlayerNumberByRank { set; get; }
        public PlayerModel[] Players { get; private set; }
    }
    public static class GameModelExtensions
    {
        public static bool IsCompleted(this GameModel game)
        {
            return game.RemainingPlayers == 0;
        }
        public static void DecreaseRemainingPlayers(this GameModel game)
        {
            game.RemainingPlayers--;
        }
        public static PlayerModel GetCurrentPlayer(this GameModel game, int index)
        {
            return game.Players[game.Order[index] - 1];
        }
        public static PlayerModel GetPlayerByRank(this GameModel game, int rank)
        {
            return game.Players[game.PlayerNumberByRank[rank - 1] - 1];
        }
        public static void InitializePlayers(this GameModel game)
        {
            for (int i = 0; i < game.Players.Length; i++)
            {
                game.Players[i] = new PlayerModel
                {
                    Rank = i + 1,
                    Number = i + 1
                };
            }
        }
        public static void SwapPositions(this GameModel game, PlayerModel player1, PlayerModel player2)
        {
            // Update Player number array in Game object
            game.PlayerNumberByRank[player1.Rank - 1] = player2.Number;
            game.PlayerNumberByRank[player2.Rank - 1] = player1.Number;

            // Update Rank property in player objects
            int player1Rank = player1.Rank;
            player1.Rank = player2.Rank;
            player2.Rank = player1Rank;
        }
    }
}
using System;

namespace GameOfDice
{
    public class PlayerModel
    {
        public int Number { set; get; }
        public int Rank { set; get; }
        public int Points { set; get; }
        public bool IsGameComplete { set; get; }
        public bool IsPreviousDiceRoll1 { set; get; }
        public bool IsPenalized { set; get; }
    }

    public static class PlayerModelExtensions
    {
        public static void UpdatePoints (this PlayerModel player, int diceValue)
        {
            player.Points += diceValue;
        }
        public static void UpdatePreviousRoll1 (this PlayerModel player, int diceValue)
        {
            player.IsPreviousDiceRoll1 = diceValue == 1;
        }

        public static bool ShouldPenalize (this PlayerModel player, int diceValue)
        {
            return player.IsPreviousDiceRoll1 && diceValue == 1;
        }

        public static void CompleteGame (this PlayerModel player)
        {
            player.IsGameComplete = true;
        }
    }
}
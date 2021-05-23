using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class GameModel_SwapPosition
    {
        [Fact]
        public void PlayerRanksShouldBeSwapped ()
        {
            GameModel game = new GameModel (3, 10);
            game.InitializePlayers();
            PlayerModel player1 = game.GetPlayerByRank (1);
            PlayerModel player2 = game.GetPlayerByRank (2);
            game.SwapPositions (player1, player2);
            Assert.True (player1.Rank == 2);
            Assert.True (player2.Rank == 1);
            PlayerModel updatedPlayer1 = game.GetPlayerByRank (1);
            PlayerModel updatedPlayer2 = game.GetPlayerByRank (2);
        }
        [Fact]
        public void PlayerRanksOrderInGameShouldBeSwapped ()
        {
            GameModel game = new GameModel (3, 10);
            game.InitializePlayers ();
            PlayerModel player1 = game.GetPlayerByRank (1);
            PlayerModel player2 = game.GetPlayerByRank (2);
            game.SwapPositions (player1, player2);
            PlayerModel updatedRank1Player= game.GetPlayerByRank (1);
            PlayerModel updatedRank2Player = game.GetPlayerByRank (2);
            Assert.True (player1.Rank == updatedRank2Player.Rank);
            Assert.True (player2.Rank == updatedRank1Player.Rank);
        }
    }
}

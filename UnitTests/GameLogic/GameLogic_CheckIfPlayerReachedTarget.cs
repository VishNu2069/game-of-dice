using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class GameLogic_CheckIfPlayerReachedTarget
    {
        [Fact]
        public void ReturnTrueIfTargetReached ()
        {
            GameModel game = new GameModel (2, 10);
            game.InitializePlayers ();
            game.Players[1].UpdatePoints (10);
            Assert.True (GameLogic.CheckIfPlayerReachedTarget (game, game.Players[1]));
        }

        [Fact]
        public void ReturnTrueIfTargetCrossed ()
        {
            GameModel game = new GameModel (2, 10);
            game.InitializePlayers ();
            game.Players[1].UpdatePoints (12);
            Assert.True (GameLogic.CheckIfPlayerReachedTarget (game, game.Players[1]));
        }

        [Fact]
        public void ReturnFalseIfTargetNotReached ()
        {
            GameModel game = new GameModel (2, 10);
            game.InitializePlayers ();
            game.Players[1].UpdatePoints (2);
            Assert.False (GameLogic.CheckIfPlayerReachedTarget (game, game.Players[1]));
        }
    }
}

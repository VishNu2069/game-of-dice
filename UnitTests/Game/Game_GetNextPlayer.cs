using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Game_GetNextPlayer
    {
        [Fact]
        public void ReturnNextPlayerWhenNotReachedLimit ()
        {
            int nextPlayer = Game.GetNextPlayer (5, 10);
            Assert.True (nextPlayer == 6);
        }

        [Fact]
        public void ReturnNextPlayerWhenReachedLimit ()
        {
            int nextPlayer = Game.GetNextPlayer (9, 10);
            Assert.True (nextPlayer == 0);
        }
    }
}

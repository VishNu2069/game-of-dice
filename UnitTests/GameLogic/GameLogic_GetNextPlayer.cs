using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class GameLogic_GetNextPlayer
    {
        [Fact]
        public void ReturnNextPlayerWhenNotReachedLimit ()
        {
            int nextPlayer = GameLogic.GetNextPlayerIndex (5, 10);
            Assert.True (nextPlayer == 6);
        }

        [Fact]
        public void ReturnNextPlayerWhenReachedLimit ()
        {
            int nextPlayer = GameLogic.GetNextPlayerIndex (9, 10);
            Assert.True (nextPlayer == 0);
        }
    }
}

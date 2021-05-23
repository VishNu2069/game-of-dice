using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class GameLogic_GiveAnotherChance
    {
        [Fact]
        public void ReturnTrueIf6 ()
        {
            Assert.True (GameLogic.GiveAnotherChance (6));
        }

        [Fact]
        public void ReturnFalseIfNot6 ()
        {
            Assert.False (GameLogic.GiveAnotherChance (5));
        }
    }
}

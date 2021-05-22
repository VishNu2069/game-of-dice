using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Game_GiveAnotherChance
    {
        [Fact]
        public void ReturnTrueIf6 ()
        {
            Assert.True (Game.GiveAnotherChance (6));
        }

        [Fact]
        public void ReturnFalseIfNot6 ()
        {
            Assert.False (Game.GiveAnotherChance (5));
        }
    }
}

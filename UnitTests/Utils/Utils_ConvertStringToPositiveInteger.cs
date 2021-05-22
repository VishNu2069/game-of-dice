using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Utils_ConvertStringToPositiveInteger
    {
        [Fact]
        public void ReturnNumberForValidNumber()
        {
            int number = Utils.ConvertStringToPositiveInteger("10");
            Assert.True(number == 10);
        }

        [Fact]
        public void ReturnMinusOneForNegativeNumber()
        {
            int number = Utils.ConvertStringToPositiveInteger("-10");
            Assert.True(number == -1);
        }
        [Fact]
        public void ReturnMinusOneForInvalidNumber()
        {
            int number = Utils.ConvertStringToPositiveInteger("10s");
            Assert.True(number == -1);
        }
        [Fact]
        public void ReturnMinusOneForNonIntegers()
        {
            int number = Utils.ConvertStringToPositiveInteger("10.2");
            Assert.True(number == -1);
        }
    }
}

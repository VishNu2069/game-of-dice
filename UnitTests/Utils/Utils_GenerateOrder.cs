using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Utils_GenerateOrder
    {
        [Fact]
        public void ReturnArrayOfLengthN()
        {
            int[] arr = Utils.GenerateOrder(10);
            Assert.True(arr.Length == 10);
        }
        [Fact]
        public void ReturnArrayWithOutDuplicates()
        {
            int[] arr = Utils.GenerateOrder(3);
            Assert.True(arr[0] != arr[1]);
            Assert.True(arr[1] != arr[2]);
            Assert.True(arr[2] != arr[0]);
        }

        [Fact]
        public void ThrowExceptionForNegativeInput()
        {
            Assert.Throws<ArgumentException>(() => Utils.GenerateOrder(-1));
        }
    }
}

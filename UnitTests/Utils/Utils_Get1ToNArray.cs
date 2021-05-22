using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Utils_Get1ToNArray
    {
        [Fact]
        public void ReturnArrayOfLengthN()
        {
            int[] arr = Utils.Get1ToNArray(10);
            Assert.True(arr.Length == 10);
        }
        [Fact]
        public void ReturnValidArray()
        {
            int[] arr = Utils.Get1ToNArray(10);
            Assert.True(arr[5] == 6);
            Assert.True(arr[1] == 2);
            Assert.True(arr[7] == 8);
            Assert.True(arr[9] == 10);
        }

        [Fact]
        public void ThrowExceptionForNegativeInput()
        {
            Assert.Throws<ArgumentException>(() => Utils.Get1ToNArray(-1));
        }
    }
}

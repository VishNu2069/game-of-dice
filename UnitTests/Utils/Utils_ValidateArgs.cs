using System;
using Xunit;
using GameOfDice;

namespace UnitTests
{
    public class Utils_ValidateArgs
    {
        [Fact]
        public void ReturnFalseForMoreThan2CommandLineInputs()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "" , "", ""});
            Assert.False(isValid);
        }

        [Fact]
        public void ReturnFalseForNonIntegerOutput()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "" , "", });
            Assert.False(isValid);
        }


        [Fact]
        public void ReturnFalseForNonIntegerOutputCase2()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "1" , "", });
            Assert.False(isValid);
        }

        [Fact]
        public void ReturnFalseForLessThan2Args()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "1"  });
            Assert.False(isValid);
        }
        [Fact]
        public void ReturnFalseForNegetiveIntegerArgs()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "-1" , "10" });
            Assert.False(isValid);
        }
        [Fact]
        public void ReturnTrueForValidArgs()
        {
            bool isValid = Utils.ValidateArgs(new string[] { "1" , "10" });
            Assert.True(isValid);
        }
    }
}

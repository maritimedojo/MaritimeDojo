using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Tests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void When_InputDoesNotHaveEnoughWords_Then_ArgumentExceptionIsThrown()
        {
            // Arrange
            var input = "two words";

            // Act
            Assert.ThrowsException<ArgumentException>(() => { var word = input.GetWordFromText(3); });
        }

        [TestMethod]
        public void When_InputTextContainsFewWords_Then_ProperOneIsReturned()
        {
            // Arrange
            var input = "few short fancy words";

            // Act
            var word = input.GetWordFromText(3);

            // Assert
            word.Should().Be("fancy");
        }

        [TestMethod]
        public void When_InputTextIsSymmetrical_Then_ItIsReturned()
        {
            // Arrange
            var input = "evil live";

            // Act
            var reversed = input.Reverse();

            // Assert
            reversed.Should().Be("evil live");
        }

        [TestMethod]
        public void When_InputTextIsPassed_Then_ItIsReversed()
        {
            // Arrange
            var input = "abcd efgh";

            // Act
            var reversed = input.Reverse();

            // Assert
            reversed.Should().Be("hgfe dcba");
        }
    }
}
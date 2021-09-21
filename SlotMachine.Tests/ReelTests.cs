using System.Collections.Generic;
using SlotMachine.Domain.Models;
using Xunit;

namespace SlotMachine.Tests
{
    public class ReelTests
    {
        private readonly Reel _classUnderTest;

        public ReelTests()
        {
            _classUnderTest = new Reel(new List<Symbol> { Symbol.A, Symbol.B, Symbol.C });
        }

        [Fact]
        public void Name()
        {
            // Act
            var subSet = _classUnderTest.GetRandomSubSet();

            // Assert
            Assert.Equal(3, subSet.Symbols.Length);
        }
    }
}

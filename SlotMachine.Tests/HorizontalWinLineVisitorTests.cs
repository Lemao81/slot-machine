using System.Linq;
using SlotMachine.Domain.Models;
using SlotMachine.Domain.Services;
using Xunit;

namespace SlotMachine.Tests
{
    public class HorizontalWinLineVisitorTests
    {
        private readonly HorizontalWinLineVisitor _classUnderTest;

        public HorizontalWinLineVisitorTests()
        {
            _classUnderTest = new HorizontalWinLineVisitor();
        }

        [Fact]
        public void Visit_NoHorizontalWinline_ZeroWinReturned()
        {
            // Arrange
            var subSetMatrx = new SubSetMatrix(new[]
            {
                new SubSet(new[] { Symbol.A, Symbol.B, Symbol.A }),
                new SubSet(new[] { Symbol.A, Symbol.A, Symbol.C }),
                new SubSet(new[] { Symbol.C, Symbol.A, Symbol.A })
            });


            // Act
            var winLines = _classUnderTest.Visit(subSetMatrx);

            // Assert
            Assert.Equal(0, winLines.Count);
        }

        [Fact]
        public void Visit_HorizontalWinlines_WinlinesReturned()
        {
            // Arrange
            var subSetMatrx = new SubSetMatrix(new[]
            {
                new SubSet(new[] { Symbol.A, Symbol.A, Symbol.C }),
                new SubSet(new[] { Symbol.A, Symbol.B, Symbol.C }),
                new SubSet(new[] { Symbol.A, Symbol.C, Symbol.C })
            });


            // Act
            var winLines = _classUnderTest.Visit(subSetMatrx);

            // Assert
            Assert.Equal(2, winLines.Count);
            Assert.Same(Symbol.A, winLines.First().Symbol);
            Assert.Same(Symbol.C, winLines.Last().Symbol);
        }
    }
}

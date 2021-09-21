using System.Linq;
using SlotMachine.Domain.Models;
using SlotMachine.Domain.Services;
using Xunit;

namespace SlotMachine.Tests
{
    public class DiagonalWinLineVisitorTests
    {
        private readonly DiagonalWinLineVisitor _classUnderTest;

        public DiagonalWinLineVisitorTests()
        {
            _classUnderTest = new DiagonalWinLineVisitor();
        }

        [Fact]
        public void Visit_NoDiagonalWinline_ZeroWinReturned()
        {
            // Arrange
            var subSetMatrx = new SubSetMatrix(new[]
            {
                new SubSet(new[] { Symbol.A, Symbol.B, Symbol.A }),
                new SubSet(new[] { Symbol.A, Symbol.B, Symbol.C }),
                new SubSet(new[] { Symbol.C, Symbol.A, Symbol.A })
            });


            // Act
            var winLines = _classUnderTest.Visit(subSetMatrx);

            // Assert
            Assert.Equal(0, winLines.Count);
        }

        [Fact]
        public void Visit_DiagonalWinlines_WinlinesReturned()
        {
            // Arrange
            var subSetMatrx = new SubSetMatrix(new[]
            {
                new SubSet(new[] { Symbol.A, Symbol.B, Symbol.A }),
                new SubSet(new[] { Symbol.B, Symbol.A, Symbol.C }),
                new SubSet(new[] { Symbol.A, Symbol.C, Symbol.A })
            });


            // Act
            var winLines = _classUnderTest.Visit(subSetMatrx);

            // Assert
            Assert.Equal(2, winLines.Count);
            Assert.Same(Symbol.A, winLines.First().Symbol);
            Assert.Same(Symbol.A, winLines.Last().Symbol);
        }
    }
}

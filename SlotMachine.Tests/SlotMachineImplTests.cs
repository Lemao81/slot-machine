using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;
using Xunit;

namespace SlotMachine.Tests
{
    public class SlotMachineImplTests
    {
        private readonly SlotMachineImpl _classUnderTest;
        private readonly IReel _reel1Fake;
        private readonly IReel _reel2Fake;
        private readonly IReel _reel3Fake;
        private readonly IWinLineVisitor _winLineVisitorFake1;
        private readonly IWinLineVisitor _winLineVisitorFake2;

        public SlotMachineImplTests()
        {
            _reel1Fake = A.Fake<IReel>();
            _reel2Fake = A.Fake<IReel>();
            _reel3Fake = A.Fake<IReel>();
            _winLineVisitorFake1 = A.Fake<IWinLineVisitor>();
            _winLineVisitorFake2 = A.Fake<IWinLineVisitor>();
            _classUnderTest = new SlotMachineImpl(new[] { _reel1Fake, _reel2Fake, _reel3Fake },
                new List<IWinLineVisitor> { _winLineVisitorFake1, _winLineVisitorFake2 });
        }

        [Fact]
        public void CurrentWin_WinLinesAdded_WinLineDataCorrect()
        {
            // Arrange
            A.CallTo(() => _reel1Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _reel2Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _reel3Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _winLineVisitorFake1.Visit(A<ISubSetMatrix>.Ignored))
                .Returns(new List<IWinLine>
                {
                    new WinLine(Symbol.A, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) }),
                    new WinLine(Symbol.B, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) }),
                });
            A.CallTo(() => _winLineVisitorFake2.Visit(A<ISubSetMatrix>.Ignored))
                .Returns(new List<IWinLine>
                {
                    new WinLine(Symbol.A, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) }),
                    new WinLine(Symbol.C, new[] { new Position(1, 1), new Position(2, 2), new Position(0, 0) }),
                });
            _classUnderTest.Play();

            // Act
            var winLines = _classUnderTest.CurrentWinLines;

            // Assert
            Assert.Equal(4, winLines.Count);
            Assert.Equal(2, winLines.Count(w => w.Symbol == Symbol.A));
            Assert.Equal(1, winLines.Count(w => w.Symbol == Symbol.B));
            Assert.Equal(1, winLines.Count(w => w.Symbol == Symbol.C));
            Assert.Equal(3, winLines.Single(w => w.Symbol == Symbol.C).Positions.Length);
            Assert.Equal(2, winLines.Single(w => w.Symbol == Symbol.C).Positions[1].X);
        }

        [Fact]
        public void CurrentWin_WinLinesExist_ReturnsExpectedAmount()
        {
            // Arrange
            A.CallTo(() => _reel1Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _reel2Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _reel3Fake.GetRandomSubSet()).Returns(new SubSet(new[] { Symbol.A, Symbol.A, Symbol.A }));
            A.CallTo(() => _winLineVisitorFake1.Visit(A<ISubSetMatrix>.Ignored))
                .Returns(new List<IWinLine>
                {
                    new WinLine(Symbol.A, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) }),
                    new WinLine(Symbol.B, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) }),
                    new WinLine(Symbol.C, new[] { new Position(0, 0), new Position(0, 0), new Position(0, 0) })
                });
            _classUnderTest.Play();

            // Act
            var actualWin = _classUnderTest.CurrentWin;

            // Assert
            Assert.Equal(45, actualWin.Cent);
        }
    }
}

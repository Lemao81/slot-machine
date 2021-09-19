using System;
using System.Collections.Generic;
using System.Linq;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class SubSetMatrix : ISubSetMatrix
    {
        private ICollection<IWinLine> _winLines;
        private readonly ISubSet[] _columnSubSets;

        public SubSetMatrix(ISubSet[] columnSubSets)
        {
            if (columnSubSets.Length != 3) throw new ArgumentException("Sub-set matrix has to consist of three column subsets");

            _columnSubSets = columnSubSets;
        }

        public (ISubSet SubSet, Position[] Positions) FirstColumn
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 0, 0, 1, 0, 2);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) SecondColumn
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(1, 0, 1, 1, 1, 2);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) ThirdColumn
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(2, 0, 2, 1, 2, 2);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) FirstRow
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 0, 1, 0, 2, 0);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) SecondRow
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 1, 1, 1, 2, 1);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) ThirdRow
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 2, 1, 2, 2, 2);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) TopDiagonal
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 0, 1, 1, 2, 2);

                return (new SubSet(symbols), positions);
            }
        }

        public (ISubSet SubSet, Position[] Positions) BottomDiagonal
        {
            get
            {
                var (symbols, positions) = GetSymbolsAndPositions(0, 2, 1, 1, 2, 0);

                return (new SubSet(symbols), positions);
            }
        }

        public ICollection<IWinLine> GetWinLines(IEnumerable<IWinLineVisitor> winLineVisitors) =>
            _winLines ??= winLineVisitors.SelectMany(v => v.Visit(this)).ToList();

        private (Symbol[] symbols, Position[] Positions) GetSymbolsAndPositions(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var symbols = new[] { _columnSubSets[x1].Symbols[y1], _columnSubSets[x2].Symbols[y2], _columnSubSets[x3].Symbols[y3] };
            var positions = new[] { new Position(x1, y1), new Position(x2, y2), new Position(x3, y3) };

            return (symbols, positions);
        }
    }
}

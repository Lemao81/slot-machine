using System;
using System.Collections.Generic;
using System.Linq;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class SubSetMatrix : ISubSetMatrix
    {
        private readonly IEnumerable<IWinLineVisitor> _winLineVisitors;
        private ICollection<IWinLine> _winLines;

        public SubSetMatrix(ISubSet[] subSets, IEnumerable<IWinLineVisitor> winLineVisitors)
        {
            if (subSets.Length != 3) throw new ArgumentException("Sub-set matrix has to consist of three subsets");

            SubSets = subSets;
            _winLineVisitors = winLineVisitors;
        }

        public ISubSet[] SubSets { get; }

        public ICollection<IWinLine> GetWinLines() => _winLines ??= _winLineVisitors.SelectMany(v => v.Visit(this)).ToList();

        public Money GetTotalWin() => GetWinLines().Aggregate(new Money(0), (money, winLine) => money + winLine.Win);
    }
}

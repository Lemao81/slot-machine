using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Services
{
    public abstract class WinLineVisitorBase : IWinLineVisitor
    {
        public abstract ICollection<IWinLine> Visit(ISubSetMatrix subSetMatrix);

        protected static ICollection<IWinLine> GetWinLines(params (ISubSet Subset, Position[] Positions)[] subSetsToPositions)
        {
            var winLines = new List<IWinLine>();
            foreach (var (subset, positions) in subSetsToPositions)
            {
                if (subset.IsWin())
                {
                    winLines.Add(new WinLine(subset.FirstSymbol, positions));
                }
            }

            return winLines;
        }
    }
}

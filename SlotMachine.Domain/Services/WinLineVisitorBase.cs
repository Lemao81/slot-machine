using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Services
{
    public abstract class WinLineVisitorBase : IWinLineVisitor
    {
        public abstract ICollection<WinLine> Visit(SubSetMatrix subSetMatrix);

        protected static ICollection<WinLine> GetWinLines(params (SubSet Subset, Position[] Positions)[] subSetsToPositions)
        {
            var winLines = new List<WinLine>();
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

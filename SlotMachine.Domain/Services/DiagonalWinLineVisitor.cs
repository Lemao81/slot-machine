using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class DiagonalWinLineVisitor : WinLineVisitorBase
    {
        public override ICollection<IWinLine> Visit(ISubSetMatrix subSetMatrix) => GetWinLines(subSetMatrix.TopDiagonal, subSetMatrix.BottomDiagonal);
    }
}

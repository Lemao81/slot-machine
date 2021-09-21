using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Services
{
    public class DiagonalWinLineVisitor : WinLineVisitorBase
    {
        public override ICollection<WinLine> Visit(SubSetMatrix subSetMatrix) => GetWinLines(subSetMatrix.TopDiagonal, subSetMatrix.BottomDiagonal);
    }
}

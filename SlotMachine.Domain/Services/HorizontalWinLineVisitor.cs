using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Services
{
    public class HorizontalWinLineVisitor : WinLineVisitorBase
    {
        public override ICollection<WinLine> Visit(SubSetMatrix subSetMatrix) =>
            GetWinLines(subSetMatrix.FirstRow, subSetMatrix.SecondRow, subSetMatrix.ThirdRow);
    }
}

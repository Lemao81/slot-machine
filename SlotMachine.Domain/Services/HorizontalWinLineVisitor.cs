using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class HorizontalWinLineVisitor : WinLineVisitorBase
    {
        public override ICollection<IWinLine> Visit(ISubSetMatrix subSetMatrix) =>
            GetWinLines(subSetMatrix.FirstRow, subSetMatrix.SecondRow, subSetMatrix.ThirdRow);
    }
}

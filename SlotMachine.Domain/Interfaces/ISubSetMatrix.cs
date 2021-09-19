using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface ISubSetMatrix
    {
        (ISubSet SubSet, Position[] Positions) FirstColumn { get; }
        (ISubSet SubSet, Position[] Positions) SecondColumn { get; }
        (ISubSet SubSet, Position[] Positions) ThirdColumn { get; }
        (ISubSet SubSet, Position[] Positions) FirstRow { get; }
        (ISubSet SubSet, Position[] Positions) SecondRow { get; }
        (ISubSet SubSet, Position[] Positions) ThirdRow { get; }
        (ISubSet SubSet, Position[] Positions) TopDiagonal { get; }
        (ISubSet SubSet, Position[] Positions) BottomDiagonal { get; }
        ICollection<IWinLine> GetWinLines(IEnumerable<IWinLineVisitor> winLineVisitors);
    }
}

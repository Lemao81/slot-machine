using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface IWinLineVisitor
    {
        ICollection<WinLine> Visit(SubSetMatrix subSetMatrix);
    }
}

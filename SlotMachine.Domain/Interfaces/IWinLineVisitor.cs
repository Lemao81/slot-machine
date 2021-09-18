using System.Collections.Generic;

namespace SlotMachine.Domain.Interfaces
{
    public interface IWinLineVisitor
    {
        ICollection<IWinLine> Visit(ISubSetMatrix subSetMatrix);
    }
}

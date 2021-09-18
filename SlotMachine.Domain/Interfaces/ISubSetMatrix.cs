using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface ISubSetMatrix
    {
        ISubSet[] SubSets { get; }
        ICollection<IWinLine> GetWinLines();
        Money GetTotalWin();
    }
}

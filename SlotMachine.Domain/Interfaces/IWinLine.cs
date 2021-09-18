using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface IWinLine
    {
        Money Win { get; }
        Symbol Symbol { get; }
        Position[] Positions { get; }
    }
}

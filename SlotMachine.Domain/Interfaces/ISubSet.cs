using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface ISubSet
    {
        bool IsWin();
        Symbol FirstSymbol { get; }
    }
}

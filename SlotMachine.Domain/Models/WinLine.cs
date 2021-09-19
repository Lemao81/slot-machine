using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class WinLine : IWinLine
    {
        public WinLine(Symbol symbol, Position[] positions)
        {
            Symbol = symbol;
            Positions = positions;
        }

        public Money Win => Symbol.WinAmount;
        public Symbol Symbol { get; }
        public Position[] Positions { get; }
    }
}

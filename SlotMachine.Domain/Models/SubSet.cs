using System;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class SubSet : ISubSet
    {
        public SubSet(Symbol[] symbols)
        {
            if (symbols.Length != 3) throw new ArgumentException("Sub-set has to consist of three symbols");

            Symbols = symbols;
        }

        public Symbol[] Symbols { get; }
        public Symbol FirstSymbol => Symbols[0];

        public bool IsWin() => Symbols[0] == Symbols[1] && Symbols[1] == Symbols[2];
    }
}

using System;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class SubSet : ISubSet
    {
        private readonly Symbol[] _symbols;

        public SubSet(Symbol[] symbols)
        {
            if (symbols.Length != 3) throw new ArgumentException("Sub-set has to consist of three symbols");

            _symbols = symbols;
        }

        public bool IsWin() => _symbols[0] == _symbols[1] && _symbols[1] == _symbols[2];

        public Symbol FirstSymbol => _symbols[0];
    }
}

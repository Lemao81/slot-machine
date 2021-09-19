using System;
using SlotMachine.Domain.Enums;

namespace SlotMachine.Domain.Models
{
    public class Symbol
    {
        private readonly string _name;

        public Symbol(string name, SymbolType symbolType, Money winAmount)
        {
            _name = name;
            WinAmount = winAmount;
        }

        public static Symbol A = new Symbol("A", SymbolType.A, new Money(10));

        public static Symbol B = new Symbol("B", SymbolType.B, new Money(15));

        public static Symbol C = new Symbol("C", SymbolType.C, new Money(20));

        public SymbolType Type { get; }

        public Money WinAmount { get; }

        public static implicit operator Symbol(SymbolType symbolType) => symbolType switch
        {
            SymbolType.A => A,
            SymbolType.B => B,
            SymbolType.C => C,
            _ => throw new ArgumentOutOfRangeException(nameof(symbolType))
        };

        public override string ToString() => _name;
    }
}

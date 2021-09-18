using System;

namespace SlotMachine.Domain.Models
{
    public readonly struct Money
    {
        private readonly int _dollar;
        private readonly byte _cent;

        public Money(int dollar, byte cent)
        {
            _dollar = dollar;
            _cent = cent;
        }

        public bool Equals(Money other)
        {
            return _dollar == other._dollar && _cent == other._cent;
        }

        public Money(int cents)
        {
            _dollar = cents / 100;
            _cent = (byte)(cents % 100);
        }

        public int Dollar => _dollar;

        public int Cent => _cent;

        public int TotalCents => ToCent();

        public static Money operator +(Money first, Money second) => new(first.ToCent() + second.ToCent());

        public static Money operator -(Money first, Money second) => second < first ? new Money(0) : new Money(first.ToCent() - second.ToCent());

        public static bool operator <(Money first, Money second) => first.ToCent() < second.ToCent();

        public static bool operator >(Money first, Money second) => first.ToCent() > second.ToCent();

        public static bool operator ==(Money first, Money second) => first.ToCent() == second.ToCent();

        public static bool operator !=(Money first, Money second) => first.ToCent() != second.ToCent();

        public int ToCent() => _dollar * 100 + _cent;

        public override string ToString() => $"${_dollar}.{_cent:00}";

        public override bool Equals(object obj) => obj is Money other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(_dollar, _cent);
    }
}

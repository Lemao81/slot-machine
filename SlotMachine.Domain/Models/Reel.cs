using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class Reel : IReel
    {
        private ReelNode _head;

        public Reel(ICollection<Symbol> symbols)
        {
            if (symbols.IsNullOrEmpty()) throw new ArgumentException("A reel with no symbols doesn't make much sense");

            _head = new ReelNode(symbols.First());
            var runner = _head;
            foreach (var symbol in symbols.Skip(1))
            {
                runner.Next = new ReelNode(symbol);
                runner = runner.Next;
            }
            runner.Next = _head;
        }

        public SubSet GetRandomSubSet()
        {
            var skip = new Random(DateTime.Now.Millisecond).Next(3, DateTime.Now.Second + 3);

            do
            {
                _head = _head.Next;
            } while (--skip > 0);

            return new SubSet(new[] { _head.Symbol, _head.Next.Symbol, _head.Next.Next.Symbol });
        }

        private class ReelNode
        {
            public ReelNode(Symbol symbol)
            {
                Symbol = symbol;
            }

            public Symbol Symbol { get; }
            public ReelNode Next { get; set; }
        }
    }
}

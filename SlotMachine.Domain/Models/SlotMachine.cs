using System;
using System.Collections.Generic;
using System.Linq;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Models
{
    public class SlotMachineImpl : ISlotMachine
    {
        private readonly IReel[] _reels;
        private readonly IEnumerable<IWinLineVisitor> _winLineVisitors;

        public SlotMachineImpl(IReel[] reels, IEnumerable<IWinLineVisitor> winLineVisitors)
        {
            if (reels.Length != 3) throw new ArgumentException("Slot machine must consist of 3 reels");

            _reels = reels;
            _winLineVisitors = winLineVisitors;
        }

        public ICollection<IWinLine> CurrentWinLines { get; private set; } = new List<IWinLine>();

        public Money CurrentWin { get; private set; } = new(0);

        public void Play()
        {
            var subSetMatrix = new SubSetMatrix(_reels.Select(r => r.GetRandomSubSet()).ToArray());
            CurrentWinLines = subSetMatrix.GetWinLines(_winLineVisitors);
            CurrentWin = CurrentWinLines.Aggregate(new Money(0), (money, winLine) => money + winLine.Win);
        }
    }
}

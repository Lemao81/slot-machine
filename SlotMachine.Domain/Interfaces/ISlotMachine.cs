using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface ISlotMachine
    {
        void Play();
        ICollection<WinLine> CurrentWinLines { get; }
        Money CurrentWin { get; }
    }
}

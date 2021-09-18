using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;

namespace SlotMachine.Api.Dtos
{
    public class GetWinLinesResponse
    {
        public ICollection<IWinLine> WinLines { get; set; }
        public Money TotalWinAmount { get; set; }
    }
}

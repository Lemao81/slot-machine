using System.Collections.Generic;
using SlotMachine.Domain.Models;

namespace SlotMachine.Api.Dtos
{
    public class GetWinLinesResponse
    {
        public ICollection<WinLine> WinLines { get; set; }
        public Money TotalWinAmount { get; set; }
    }
}

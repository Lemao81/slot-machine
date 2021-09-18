using System.Collections.Generic;
using SlotMachine.Domain.Enums;

namespace SlotMachine.Domain.Models
{
    public class ReelOptions
    {
        public static string SectionName => "Reels";

        public IEnumerable<SymbolType> Reel1 { get; set; }
        public IEnumerable<SymbolType> Reel2 { get; set; }
        public IEnumerable<SymbolType> Reel3 { get; set; }
    }
}

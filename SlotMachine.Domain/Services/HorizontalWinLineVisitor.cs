using System.Collections.Generic;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class HorizontalWinLineVisitor : IWinLineVisitor
    {
        public ICollection<IWinLine> Visit(ISubSetMatrix subSetMatrix)
        {
            throw new System.NotImplementedException();
        }
    }
}

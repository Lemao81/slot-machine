using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface IReel
    {
        SubSet GetRandomSubSet();
    }
}

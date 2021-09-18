using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly ISlotMachine _slotMachine;

        public SlotMachineService(ISlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }

        public ISubSetMatrix CreateSubSetMatrix() => _slotMachine.GetRandomSubSetMatrix();
    }
}

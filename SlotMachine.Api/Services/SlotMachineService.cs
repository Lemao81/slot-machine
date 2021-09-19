using SlotMachine.Api.Dtos;
using SlotMachine.Api.Interfaces;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Api.Services
{
    public class SlotMachineService : ISlotMachineService
    {
        private readonly ISlotMachine _slotMachine;

        public SlotMachineService(ISlotMachine slotMachine)
        {
            _slotMachine = slotMachine;
        }

        public GetWinLinesResponse GetWinLinesResponse()
        {
            _slotMachine.Play();

            return new GetWinLinesResponse
            {
                WinLines = _slotMachine.CurrentWinLines,
                TotalWinAmount = _slotMachine.CurrentWin
            };
        }
    }
}

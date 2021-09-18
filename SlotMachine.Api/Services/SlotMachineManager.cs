using SlotMachine.Api.Dtos;
using SlotMachine.Api.Interfaces;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Api.Services
{
    public class SlotMachineManager : ISlotMachineManager
    {
        private readonly ISlotMachineService _slotMachineService;

        public SlotMachineManager(ISlotMachineService slotMachineService)
        {
            _slotMachineService = slotMachineService;
        }

        public GetWinLinesResponse GetWinLinesResponse()
        {
            var subSetMatrix = _slotMachineService.CreateSubSetMatrix();

            return new GetWinLinesResponse
            {
                WinLines = subSetMatrix.GetWinLines(),
                TotalWinAmount = subSetMatrix.GetTotalWin()
            };
        }
    }
}

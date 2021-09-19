using Microsoft.AspNetCore.Mvc;
using SlotMachine.Api.Dtos;
using SlotMachine.Api.Interfaces;

namespace SlotMachine.Api.Controllers
{
    public class SlotMachineController : ControllerBase
    {
        private readonly ISlotMachineService _slotMachineService;

        public SlotMachineController(ISlotMachineService slotMachineService)
        {
            _slotMachineService = slotMachineService;
        }

        [HttpGet]
        public ActionResult<GetWinLinesResponse> GetWinLines() => _slotMachineService.GetWinLinesResponse();
    }
}

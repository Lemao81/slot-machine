using Microsoft.AspNetCore.Mvc;
using SlotMachine.Api.Dtos;
using SlotMachine.Api.Interfaces;

namespace SlotMachine.Api.Controllers
{
    public class SlotMachineController : ControllerBase
    {
        private readonly ISlotMachineManager _slotMachineManager;

        public SlotMachineController(ISlotMachineManager slotMachineManager)
        {
            _slotMachineManager = slotMachineManager;
        }

        [HttpGet]
        public ActionResult<GetWinLinesResponse> GetWinLines() => _slotMachineManager.GetWinLinesResponse();
    }
}

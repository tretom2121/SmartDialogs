using Microsoft.AspNetCore.Mvc;
using SmartDialogs.API.Models;
using SmartDialogs.API.Services;

namespace SmartDialogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DialogController : ControllerBase
    {
        private readonly DialogService DialogService;

        public DialogController()
        {
            DialogService = new DialogService();
        }

        [HttpGet("start")]
        public ActionResult<DialogState> Start()
        {
            return DialogService.GetInitialState();
        }

        [HttpPost("next")]
        public ActionResult<DialogState> Next(DialogState currentState)
        {
            return DialogService.GetNextState(currentState);
        }
    }
}
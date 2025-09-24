using Microsoft.AspNetCore.Mvc;
using SmartDialogs.API.Models;
using SmartDialogs.API.Services;

namespace SmartDialogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class DialogController(IDialogService dialogService) : ControllerBase
    {
        [HttpGet("start")]
        public ActionResult<DialogState> Start()
        {
            return dialogService.GetInitialState();
        }

        [HttpPost("next")]
        public ActionResult<DialogState> Next(DialogState currentState)
        {
            return dialogService.GetNextState(currentState);
        }
    }
}
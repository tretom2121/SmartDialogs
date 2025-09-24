using Microsoft.AspNetCore.Mvc;
using SmartDialogs.Core.Models;
using SmartDialogs.Core.Services;

namespace SmartDialogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DialogController(IDialogServiceProvider dialogServiceProvider) : ControllerBase
    {
        [HttpGet("start/{key}")]
        public ActionResult<DialogState> Start(string key)
        {
            return dialogServiceProvider.GetDialogService(key).GetInitialState();
        }

        [HttpPost("next/{key}")]
        public ActionResult<DialogState> Next(string key, [FromBody] DialogState currentState)
        {
            return dialogServiceProvider.GetDialogService(key).GetNextState(currentState);
        }
        
        [HttpPost("preview/{key}")]
        public ActionResult<DialogState> Preview(string key, [FromBody] DialogState currentState)
        {
            return dialogServiceProvider.GetDialogService(key).PreviewNextState(currentState);
        }
    }
}
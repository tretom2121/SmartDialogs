using Microsoft.AspNetCore.Mvc;

namespace SmartDialogs.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ["Hello", "World", "from", "ASP.NET Core!"];
        }
    }
}
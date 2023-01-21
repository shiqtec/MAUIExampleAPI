using Microsoft.AspNetCore.Mvc;

namespace MAUIExampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            return 1;
        }
    }
}
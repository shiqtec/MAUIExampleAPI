using MAUIExampleAPI.DAO.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MAUIExampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoDAO _todoService;

        public TodoController(ITodoDAO todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var todos = await _todoService.GetTodos();
            return Ok(todos);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MAUIExampleAPI.DAO.Interfaces;
using MAUIExampleAPI.Models.Requests;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            var todo = await _todoService.GetTodo(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(TodoRequest todo)
        {
            var todoResponse = await _todoService.AddTodo(todo);
            return CreatedAtAction(nameof(GetTodo), new { todoResponse.Id }, todoResponse);
        }
    }
}
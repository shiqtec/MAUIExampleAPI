using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MAUIExampleAPI.Models.Responses;
using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.DAO.Interfaces;
using MAUIExampleAPI.Models.Requests;

namespace MAUIExampleAPI.DAO
{
    public class TodoDAO : ITodoDAO
    {
        private readonly TodoDbContext _dbContext;
        private readonly IMapper _mapper;

        public TodoDAO(TodoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TodoResponse> AddTodo(TodoRequest todo)
        {
            var dbTodo = _mapper.Map<Todo>(todo);
            
            await _dbContext.AddAsync(dbTodo);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TodoResponse>(dbTodo);
        }

        public async Task<TodoResponse> GetTodo(int id)
        {
            var dbTodo = await _dbContext.Todos.FirstOrDefaultAsync(todos => todos.Id == id);
            return _mapper.Map<TodoResponse>(dbTodo);
        }

        public async Task<List<TodoResponse>> GetTodos()
        {
            var dbTodos = await _dbContext.Todos.ToListAsync();
            return _mapper.Map<List<TodoResponse>>(dbTodos);
        }

        public async Task<TodoResponse> UpdateTodo(int id, TodoRequest todo)
        {
            var dbTodo = await _dbContext.Todos.FirstOrDefaultAsync(todos => todos.Id == id);

            if(dbTodo == null)
            {
                return null;
            }

            dbTodo.TodoName = todo.TodoName;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TodoResponse>(dbTodo);
        }
    }
}

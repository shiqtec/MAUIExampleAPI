using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.DAO.Interfaces;
using MAUIExampleAPI.Models.DTOs;

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

        public async Task<TodoDTO> AddTodo(TodoDTO todo)
        {
            var dbTodo = _mapper.Map<Todo>(todo);
            
            await _dbContext.AddAsync(dbTodo);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TodoDTO>(dbTodo);
        }

        public async Task<TodoDTO> GetTodo(int id)
        {
            var dbTodo = await _dbContext.Todos.FirstOrDefaultAsync(todos => todos.Id == id);
            return _mapper.Map<TodoDTO>(dbTodo);
        }

        public async Task<List<TodoDTO>> GetTodos()
        {
            var dbTodos = await _dbContext.Todos.ToListAsync();
            return _mapper.Map<List<TodoDTO>>(dbTodos);
        }

        public async Task<TodoDTO> UpdateTodo(int id, TodoDTO todo)
        {
            var dbTodo = await _dbContext.Todos.FirstOrDefaultAsync(todos => todos.Id == id);

            if(dbTodo == null)
            {
                return null;
            }

            dbTodo.TodoName = todo.TodoName;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TodoDTO>(dbTodo);
        }

        public async Task<TodoDTO> DeleteTodo(int id)
        {
            var dbTodo = await _dbContext.Todos.FirstOrDefaultAsync(todos => todos.Id == id);

            if (dbTodo == null)
            {
                return null;
            }

            _dbContext.Remove(dbTodo);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TodoDTO>(dbTodo);
        }
    }
}

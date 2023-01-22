using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MAUIExampleAPI.Models.Responses;
using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.DAO.Interfaces;

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

        public async Task<List<TodoResponse>> GetTodos()
        {
            var dbTodos = await _dbContext.Todos.ToListAsync();
            return _mapper.Map<List<TodoResponse>>(dbTodos);
        }
    }
}

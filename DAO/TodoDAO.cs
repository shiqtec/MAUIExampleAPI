using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MAUIExampleAPI.DAO
{
    public class TodoDAO : ITodoDAO
    {
        private readonly TodoDbContext _dbContext;

        public TodoDAO(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Todo>> GetTodos()
        {
            var dbTodos = await _dbContext.Todos.ToListAsync();
            return dbTodos;
        }
    }
}

using MAUIExampleAPI.Models.Database;

namespace MAUIExampleAPI.DAO.Interfaces
{
    public interface ITodoDAO
    {
        public Task<List<Todo>> GetTodos();
    }
}

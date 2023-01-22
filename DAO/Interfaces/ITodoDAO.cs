using MAUIExampleAPI.Models.Responses;

namespace MAUIExampleAPI.DAO.Interfaces
{
    public interface ITodoDAO
    {
        public Task<List<TodoResponse>> GetTodos();
    }
}

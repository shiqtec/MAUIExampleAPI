using MAUIExampleAPI.Models.Requests;
using MAUIExampleAPI.Models.Responses;

namespace MAUIExampleAPI.DAO.Interfaces
{
    public interface ITodoDAO
    {
        public Task<List<TodoResponse>> GetTodos();
        public Task<TodoResponse> GetTodo(int id);
        public Task<TodoResponse> AddTodo(TodoRequest todo);
        public Task<TodoResponse> UpdateTodo(int id, TodoRequest todo);
    }
}

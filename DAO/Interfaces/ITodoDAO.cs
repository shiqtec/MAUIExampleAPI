using MAUIExampleAPI.Models.DTOs;

namespace MAUIExampleAPI.DAO.Interfaces
{
    public interface ITodoDAO
    {
        public Task<List<TodoDTO>> GetTodos();
        public Task<TodoDTO> GetTodo(int id);
        public Task<TodoDTO> AddTodo(TodoDTO todo);
        public Task<TodoDTO> UpdateTodo(int id, TodoDTO todo);
        public Task<TodoDTO> DeleteTodo(int id);
    }
}

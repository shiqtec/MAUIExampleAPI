using AutoMapper;
using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.Models.DTOs;

namespace MAUIExampleAPI.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDTO>();
            CreateMap<TodoDTO, Todo>();
        }
    }
}

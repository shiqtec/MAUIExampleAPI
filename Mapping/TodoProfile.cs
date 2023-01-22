﻿using AutoMapper;
using MAUIExampleAPI.Models.Database;
using MAUIExampleAPI.Models.Responses;

namespace MAUIExampleAPI.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoResponse>();
        }
    }
}

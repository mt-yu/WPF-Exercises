﻿using AutoMapper;
using MyToDo.Api.Context;
using MyToDo.Share.DataTransfers;

namespace MyToDo.Api.Extensions
{
    public class AutoMapperProFile : MapperConfigurationExpression
    {
        public AutoMapperProFile()
        {
            CreateMap<ToDo, ToDoDto>().ReverseMap();
        }
    }
}

﻿using AutoMapper;
using ELibrary.Models;

namespace ELibrary.Dtos.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetBookDto>();
            CreateMap<AppUser, GetUserDto>();
        }
    }
}

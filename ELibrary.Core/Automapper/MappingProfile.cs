using AutoMapper;
using ELibrary.Dtos;
using ELibrary.Models;

namespace ELibrary.Core.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetBookDto>();
        }
    }
}

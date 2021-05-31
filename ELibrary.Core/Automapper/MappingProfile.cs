using AutoMapper;
using ELibrary.Models;

namespace ELibrary.Dtos.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, GetUserDto>();
        }
    }
}

using AutoMapper;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Core.Automapper
{
    class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookDto, Book>();
            CreateMap<Book, AddBookDto>();
            CreateMap<AddBookResponseDto, Book>();
            CreateMap<UpdateBookResponseDto, Book>(); 
            CreateMap<Book, BookResourceParameters>();
            CreateMap<Book, GetBookDto>();
        }
    }
}

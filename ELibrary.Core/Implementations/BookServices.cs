using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        public BookServices(IRepository<Book> bookRepository, IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public async Task<ResponseDto<AddBookResponseDto>> AddBook(AddBookDto book)
        {

            var response = new ResponseDto<AddBookResponseDto>();

            if (book == null)
            {
                response.Data = null;
                response.StatusCode = 404;
                response.Success = false;
                response.Message = "Not Found";
            }

            var newBook = _mapper.Map<Book>(book);

            var success = await _bookRepository.Save(newBook);

            var bookFromDb = _mapper.Map<AddBookResponseDto>(newBook);

            response.Data = bookFromDb;
            response.StatusCode = 201;
            response.Success = true;
            response.Message = "New Book Added";

            return response;

        }

        public async Task<ResponseDto<Pagination<GetBookDto>>> GetBook(BookResourceParameters bookResource)
        {
            var response = new ResponseDto<Pagination<GetBookDto>>();

            if (string.IsNullOrEmpty(bookResource.Title))
            {
                response.Data = null;
                response.StatusCode = 404;
                response.Success = false;
                response.Message = "Not Found";
            }


            var book = _mapper.Map<Book>(bookResource);

            var bookFromDb = _bookRepo.GetBookByTitle(book.Title);

            var mappedBook = bookFromDb.Select(book => _mapper.Map<GetBookDto>(book));

            var paginatedBooks = await Pagination<GetBookDto>.CreateAsync(mappedBook, 1, 15);

            response.Data = paginatedBooks;
            response.StatusCode = 200;
            response.Success = true;


            return response;
        }

        public async Task<ResponseDto<Pagination<GetBookDto>>> GetByCategory(string CategoryName, int pageIndex, int pageSize)
        {
            var books = _bookRepo.GetByCategoryName(CategoryName);
            if (books == null)
            {
                return new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = null,
                    Message = "Not found",
                    StatusCode = 404,
                    Success = false
                };
            }
            var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
            var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);
            var response = new ResponseDto<Pagination<GetBookDto>>
            {
                Data = paginatedResult,
                Message = "Not found",
                StatusCode = 404,
                Success = false
            };
            return response;
        }

        public async Task<ResponseDto<UpdateBookResponseDto>> UpdateBook(UpdateBookDto book)
        {

            var response = new ResponseDto<UpdateBookResponseDto>();

            if (book == null)
            {
                response.Data = null;
                response.StatusCode = 404;
                response.Success = false;
                response.Message = "Not Found";
            }

            var newBook = _mapper.Map<Book>(book);

            var bookAdded = await _bookRepository.Update(newBook);

            var bookFromDb = _mapper.Map<UpdateBookResponseDto>(newBook);

            response.Data = bookFromDb;
            response.StatusCode = 201;
            response.Success = true;
            response.Message = "New Book Added";

            return response;

        }


    }
}

﻿using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICloudinaryServices _cloudinaryService;
        private readonly IMapper _mapper;

        public BookServices(IBookRepository bookRepository, ICloudinaryServices cloudinaryService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _cloudinaryService = cloudinaryService;
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

            var bookFromDb = _bookRepository.GetBookByTitle(book.Title);

            var mappedBook = bookFromDb.Select(book => _mapper.Map<GetBookDto>(book));

            var paginatedBooks = await Pagination<GetBookDto>.CreateAsync(mappedBook, 1, 15);

            response.Data = paginatedBooks;
            response.StatusCode = 200;
            response.Success = true;


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

        public async Task<ResponseDto<GetBookDto>> UpdatePhotoBook(int bookId, AddPhotoDto photo)
        {
            var response = new ResponseDto<GetBookDto>();
            var file = photo.PhotoFile;
            var book = await _bookRepository.GetById(bookId);

            if (book == null)
            {
                response.Data = null;
                response.StatusCode = 404;
                response.Success = false;
                response.Message = "Not Found";
                return response;
            }

            var PhotoInfo = await _cloudinaryService.UploadImage(file);
            book.PhotoUrl = PhotoInfo.SecureUrl.ToString();

            await _bookRepository.Update(book);

            var bookDto = _mapper.Map<GetBookDto>(book);

            response.Data = bookDto;
            response.StatusCode = 200;
            response.Success = true;
            response.Message = "Image successfully updated";

            return response;
        }
        public async Task<ResponseDto<Pagination<GetBookDto>>> GetBookBySearchTerm(string query, string searchProperty, int pageIndex, int pageSize)
        {
            if (searchProperty == null || query == null)
            {
                return new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = null,
                    Message = "search parameter should not be null",
                    StatusCode = 400,
                    Success = false
                };
            }
            if (searchProperty == "ISBN")
            {
                var books = _bookRepo.GetAll().Where(e => e.ISBN == query);
                var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
                var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);

                var response = new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = paginatedResult,
                    Message = $"you have successfuly quarried books with the ISBN {searchProperty} sesrch property.",
                    StatusCode = 200,
                    Success = true
                };

                return response;
            }

            if (searchProperty == "Title")
            {
                var books = _bookRepo.GetAll().Where(e => e.Title.Contains(query));
                var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
                var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);

                var response = new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = paginatedResult,
                    Message = $"you have successfuly quarried books with the Title {query} search property.",
                    StatusCode = 200,
                    Success = true
                };
                return response;
            }

            if (searchProperty == "Author")
            {
                var books = _bookRepo.GetAll().Where(e => e.Author == query);
                var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
                var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);

                var response = new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = paginatedResult,
                    Message = $"you have successfuly quarried books with the Author {query} search property.",
                    StatusCode = 200,
                    Success = true
                };
                return response;
            }

            

            if (searchProperty == "Publisher")
            {
                var books = _bookRepo.GetAll().Where(e => e.Publisher == query);
                var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
                var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);

                var response = new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = paginatedResult,
                    Message = $"you have successfuly quarried books with the Publisher {query} search property.",
                    StatusCode = 200,
                    Success = true
                };
                return response;
            }

            if (searchProperty == "PublishedYear")
            {
                var books = _bookRepo.GetAll().Where(e => e.PublishedDate.Year == Convert.ToDateTime(query).Year);
                var bookDto = books.Select(book => _mapper.Map<GetBookDto>(book));
                var paginatedResult = await Pagination<GetBookDto>.CreateAsync(bookDto, pageIndex, pageSize);
                var response = new ResponseDto<Pagination<GetBookDto>>
                {
                    Data = paginatedResult,
                    Message = $"you have successfuly quarried books Published in the year {Convert.ToDateTime(query).Year} search property.",
                    StatusCode = 200,
                    Success = true
                };
                return response;
            }
            return new ResponseDto<Pagination<GetBookDto>>
            {
                Data = null,
                Message = "Not found",
                StatusCode = 400,
                Success = false
            };
        }


    }
}

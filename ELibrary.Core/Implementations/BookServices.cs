using AutoMapper;
using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Data.Repositories.Implementations;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookServices : IBookServices
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly ICloudinaryServices _cloudinaryService;
        private readonly IMapper _mapper;

        public BookServices(IRepository<Book> bookRepository, ICloudinaryServices cloudinaryService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _cloudinaryService = cloudinaryService;
            _mapper = mapper;
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
    }
}

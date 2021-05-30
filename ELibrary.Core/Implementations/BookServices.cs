using ELibrary.Core.Abstractions;
using ELibrary.Data.Repositories.Abstractions;
using ELibrary.Dtos;
using ELibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Implementations
{
    public class BookServices
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly ICloudinaryServices _cloudinaryService;

        public BookServices(IRepository<Book> bookRepository, ICloudinaryServices cloudinaryService)
        {
            _bookRepository = bookRepository;
            _cloudinaryService = cloudinaryService;
        }
        //public async Task<ResponseDto<GetBookDto>> AddPhotoBook(int id, AddPhotoDto photo)
        //{
        //    var file = photo.PhotoFile;
        //    var book = await _bookRepository.GetById(id);
        //    if(book == null)
        //    {
        //       // ResponseDto
        //    }
        //    var PhotoInfo = await _cloudinaryService.UploadImage(file);
        //    book.PhotoUrl = PhotoInfo.SecureUrl.ToString();
        //    await _bookRepository.Save(book);
        //    //return book;

        //}
    }
}

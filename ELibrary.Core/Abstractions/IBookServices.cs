using ELibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Abstractions
{
    public interface IBookServices
    {
        public Task<ResponseDto<GetBookDto>> UpdatePhotoBook(int bookId, AddPhotoDto photo);
    }
}

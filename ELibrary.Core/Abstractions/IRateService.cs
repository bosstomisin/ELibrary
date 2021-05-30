using ELibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Core.Abstractions
{
   public interface IRateService
    {
        Task<ResponseDto<bool>> RateBook(int bookId, int ratingValue, string userId);
    }
}

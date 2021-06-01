using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Dtos
{
   public class AddPhotoDto
    {
        public IFormFile PhotoFile { get; set; }
    }
}

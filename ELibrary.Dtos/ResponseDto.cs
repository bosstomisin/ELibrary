using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Dtos
{
    public class ResponseDto<T>
    {
        public int StatusCode {get; set;}
        public bool Success { get; set; } = false;
        public T Data { get; set; }
        public string Message { get; set; }
    }
}

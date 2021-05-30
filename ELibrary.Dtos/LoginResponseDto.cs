using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Dtos
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string  Email { get; set; }
        public string Token { get; set; }

    }
}

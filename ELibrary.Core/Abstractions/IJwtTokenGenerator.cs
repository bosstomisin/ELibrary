using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.Core.Abstractions
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(string username, string userId, string email, IConfiguration config, string[] roles);
    }
}

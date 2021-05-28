﻿using ELibrary.Core.Abstractions;
using ELibrary.Core.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.MVC.Extensions
{
    public static class DIServiceExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        }
    }
}

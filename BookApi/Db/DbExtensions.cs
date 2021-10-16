﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApi.Db
{
    public static class DbExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookContext>(
                o => o.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
               /* b => b.MigrationsAssembly("libraryDatabase")));*/
        }
    }
}
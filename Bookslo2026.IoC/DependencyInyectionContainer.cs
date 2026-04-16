using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Data.Repositories;
using Bookslo2026.Entities;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Services;
using Bookslo2026.Service.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.IoC
{
    public static class DependencyInyectionContainer
    {
        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksDbContext>();
            services.AddScoped<IAuthorsRepository, AuthorRepository>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidator<Author>, AuthorValidator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services.BuildServiceProvider();
        }
    }
}

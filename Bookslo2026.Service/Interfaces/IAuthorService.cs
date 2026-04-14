using Bookslo2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author? GetById(int id);
        (bool Success, List<string> Errors) Add(Author author);
        (bool Success, List<string> Errors) Update(Author author);
        (bool Success, List<string> Errors) Delete(int id);
    }
}

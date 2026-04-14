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
        bool Add(Author author);
        bool Update(Author author);
        bool Delete(int id);
    }
}

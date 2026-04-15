using Bookslo2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Interfaces
{
    public interface IAuthorsRepository
    {
        List<Author> GetAll();
        Author? GetById(int id);
        bool Exist(string FirstName, string LastName, int? authorId=null);
        void Delete(int id);
        void Update(Author author);
        void Add(Author author);
    }
}

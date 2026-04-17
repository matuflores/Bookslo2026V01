using Bookslo2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Interfaces
{
    public interface IPublishersRepository
    {
        List<Publisher> GetAll();
        Publisher? GetById(int id);
        //bool Exist(string FirstName, string LastName, int? authorId = null);
        void Delete(int id);
        //void Update(Author author);
        void Add(Publisher publisher);
    }
}

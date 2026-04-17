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
        bool Exist(string Name, string Country, string mail, int? publisherId = null);
        void Delete(int id);
        void Update(Publisher publisher);
        void Add(Publisher publisher);
    }
}

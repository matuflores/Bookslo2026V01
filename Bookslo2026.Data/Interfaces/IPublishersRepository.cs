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
        //public int PublisherId { get; set; }
        //public string Name { get; set; } = null!;
        //public string Country { get; set; } = null!;
        //public string? Email { get; set; }
        void Delete(int id);
        void Update(Publisher publisher);
        void Add(Publisher publisher);
    }
}

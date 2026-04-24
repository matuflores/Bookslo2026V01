using Bookslo2026.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Interfaces
{
    public interface IBooksRepository
    {
        List<Book> GetAll();
        Book? GetById(int id);
        bool Exist(string Title,int? bookid = null);
        void Delete(int id);
        void Update(Book book);
        void Add(Book book);
        
    }
}

using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Repositories
{
    public class BookRepository : IBooksRepository
    {
        private readonly BooksDbContext _context;
        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string Title, int? bookid = null)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public Book? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}

using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            _context.Books.Add(book);
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return;
            _context.Books.Remove(book);
        }

        public bool Exist(string Title, int authorId, int publisherId, decimal Price, int? bookId = null)
        {
            Book? book;
            if (bookId == null)
            {
                book = _context.Books.FirstOrDefault(b =>
                b.Title == Title && b.AuthorId == authorId && b.PublisherId == publisherId && b.Price == Price);
            }
            else
            {
                book = _context.Books.FirstOrDefault(b =>
                b.Title == Title && b.AuthorId == authorId && b.PublisherId == publisherId && b.Price == Price && b.BookId != bookId);
            }
            return book != null;
        }

        public List<Book> GetAll()
        {
            return _context.Books.AsNoTracking().ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}

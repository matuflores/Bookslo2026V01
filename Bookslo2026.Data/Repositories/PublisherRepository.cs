using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Repositories
{
    public class PublisherRepository : IPublishersRepository
    {
        private readonly BooksDbContext _context;
        public PublisherRepository(BooksDbContext context)
        {
            _context = context;
        }

        public void Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
        }

        public List<Publisher> GetAll()
        {
            return _context.Publishers.AsNoTracking().ToList();
        }

        //public Publisher? GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

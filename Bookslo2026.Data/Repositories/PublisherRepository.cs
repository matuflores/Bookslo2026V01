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

        public void Delete(int id)
        {
            var publisher = _context.Publishers.Find(id);//GetById(id);
            if (publisher == null) return;
            _context.Publishers.Remove(publisher);
        }

        public bool Exist(string name, string country, string mail, int? publisherId = null)
        {
            Publisher? publisher;
            if (publisherId == null)
            {
                publisher = _context.Publishers.FirstOrDefault(p =>
                p.Name == name && p.Country == country && p.Email==mail);
            }
            else 
            { 
                publisher = _context.Publishers.FirstOrDefault(p=>
                p.Name == name && p.Country == country && p.Email == mail && p.PublisherId!=publisherId);
            }
            return publisher != null;
        }

        public List<Publisher> GetAll()
        {
            return _context.Publishers.AsNoTracking().ToList();
        }

        public Publisher? GetById(int id)
        {
            return _context.Publishers.Find(id);
        }

        public void Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
        }
    }
}

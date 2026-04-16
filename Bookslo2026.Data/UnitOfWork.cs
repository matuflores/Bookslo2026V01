using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksDbContext _context;

        public UnitOfWork(BooksDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

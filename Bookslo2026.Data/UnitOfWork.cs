using Bookslo2026.Data.Interfaces;
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

        public IAuthorsRepository Authors { get; }

        public IPublishersRepository Publishers { get; }// aca se puede agregar la logica para crear una instancia de PublishersRepository, por ejemplo: new PublishersRepository(_context);

        public IBooksRepository Books { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using Bookslo2026.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data
{
    public interface IUnitOfWork
    {
        IAuthorsRepository Authors { get; }

        IPublishersRepository Publishers { get; }

        IBooksRepository Books { get; }

        void Save();
    }
}

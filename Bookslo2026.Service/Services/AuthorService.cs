using Bookslo2026.Data.Interfaces;
using Bookslo2026.Data.Repositories;
using Bookslo2026.Entities;
using Bookslo2026.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorsRepository? _repository;

        public AuthorService()
        {
            _repository=new AuthorRepository();
        }
        public bool Add(Author author)
        {
            try
            {
                _repository.Add(author);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Author> GetAll()
        {
            return _repository.GetAll();
        }

        public Author? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(Author author)
        {
            try
            {
                _repository.Update(author);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

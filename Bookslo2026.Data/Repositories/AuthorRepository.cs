using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Data.Repositories
{
    public class AuthorRepository : IAuthorsRepository
    {
        private readonly BooksDbContext _context;
        public AuthorRepository(BooksDbContext context)
        {
            _context = context;
        }
        public void Add(Author author)
        {
            _context.Authors.Add(author);
            //using (var context = new BooksDbContext())
            //{
            //    context.Authors.Add(author);
            //    context.SaveChanges();
            //}
        }

        public void Delete(int id)
        {
            //using (var context = new BooksDbContext())
            //{
            var author = _context.Authors.Find(id);//GetById(id);
            if (author == null) return;
            _context.Authors.Remove(author);
            //_context.SaveChanges();
            //}
        }

        public bool Exist(string firstname, string lastname, int? authorId = null)
        {
            //using (var context = new BooksDbContext())
            //{
                Author? author;
                if (authorId==null)
                {
                    author = _context.Authors.FirstOrDefault(a =>
                            a.FirstName == firstname && a.LastName == lastname); 
                }
                else
                {
                    author = _context.Authors.FirstOrDefault(a =>
                            a.FirstName == firstname && a.LastName == lastname && a.AuthorId != authorId);//esto lo pongo para que no me diga que existe el mismo autor cuando estoy editando un autor y no cambio su nombre, ya que el id del autor que estoy editando es igual al id del autor que ya existe
                }
                return author != null;
            //}
        }

        public List<Author> GetAll()
        {
            return _context.Authors.AsNoTracking().ToList();
            //using (var context = new BooksDbContext())
            //{
            //    var authors=context.Authors.AsNoTracking().ToList();
            //    return authors;
            //}
        }

        public Author? GetById(int id)
        {
            return _context.Authors.Find(id);
            //using (var context = new BooksDbContext())
            //{
            //    return context.Authors.Find(id);
            //}
        }

        public void Update(Author author)
        {
            //using (var context=new BooksDbContext())
            //{
            //    context.Authors.Update(author);
            //    context.SaveChanges();
            //}
            _context.Authors.Update(author);
        }
    }
}

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
        public void Add(Author author)
        {
            using (var context = new BooksDbContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new BooksDbContext())
            {
                var author = GetById(id);
                if (author == null) return;
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }

        public bool Exist(string firstname, string lastname, int? authorId = null)
        {
            using (var context = new BooksDbContext())
            {
                Author? author;
                if (authorId==null)
                {
                    author = context.Authors.FirstOrDefault(a =>
                            a.FirstName == firstname && a.LastName == lastname); 
                }
                else
                {
                    author = context.Authors.FirstOrDefault(a =>
                            a.FirstName == firstname && a.LastName == lastname && a.AuthorId != authorId);//esto lo pongo para que no me diga que existe el mismo autor cuando estoy editando un autor y no cambio su nombre, ya que el id del autor que estoy editando es igual al id del autor que ya existe
                }
                return author != null;
            }
        }

        public List<Author> GetAll()
        {
            using (var context = new BooksDbContext())
            {
                var authors=context.Authors.AsNoTracking().ToList();
                return authors;
            }
        }

        public Author? GetById(int id)
        {
            using (var context = new BooksDbContext())
            {
                return context.Authors.Find(id);
            }
        }

        public void Update(Author author)
        {
            using (var context=new BooksDbContext())
            {
                context.Authors.Update(author);
                context.SaveChanges();
            }
        }
    }
}

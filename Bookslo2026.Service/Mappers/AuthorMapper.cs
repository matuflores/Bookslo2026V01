using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Mappers
{
    public static class AuthorMapper // es una clase estatica porque no necesitamos instanciarla para usarla, ya que solo tiene metodos estaticos
    {
        public static AuthorListDto ToAuthorListDto(Author author)
        {
            return new AuthorListDto
            {
                AuthorId = author.AuthorId,
                FullName=$"{author.FirstName} {author.LastName}"
            };
        }//una ves que tengo hecho la conexion lo uso en Services
    }
}

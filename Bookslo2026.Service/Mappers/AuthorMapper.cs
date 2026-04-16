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

        public static AuthorUpdateDto ToAuthorUpdateDto(Author author)
        {
            return new AuthorUpdateDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }

        public static Author toEntity(AuthorUpdateDto authorDto)//este metodo es para convertir un AuthorUpdateDto a un Author,
                                                                //ya que el AuthorUpdateDto es el que recibimos del cliente y
                                                                //el Author es el que tenemos en la base de datos
        {
            return new Author
            {
                AuthorId = authorDto.AuthorId,
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
            };
        }

        public static AuthorDetailsDto ToAuthorDetailsDto(Author author)
        {
            return new AuthorDetailsDto
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }

        public static Author toEntity(AuthorCreateDto authorDto)//este metodo es para convertir un AuthorCreateDto a un //Author, ya que el AuthorCreateDto es el que recibimos //del cliente y el Author es el que tenemos en la base de datos
        {
            return new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
            };
        }
    }

    
}

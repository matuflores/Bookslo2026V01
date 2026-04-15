using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Interfaces
{
    public interface IAuthorService
    {
        //List<Author> GetAll();
        List<AuthorListDto> GetAll();
        AuthorDetailsDto? GetById(int id);
        AuthorUpdateDto? GetForUpdate(int id);// este metodo es para obtener un autor para actualizarlo, porque el AuthorUpdateDto tiene el AuthorId, y el AuthorListDto no lo tiene, entonces necesitamos este metodo para obtener el AuthorUpdateDto
        //bool Exist(string FirstName, string LastName); lo anulo porque es propio del .Data
        (bool Success, List<string> Errors) Add(AuthorCreateDto author);
        (bool Success, List<string> Errors) Update(AuthorUpdateDto author);
        (bool Success, List<string> Errors) Delete(int id);
    }
}

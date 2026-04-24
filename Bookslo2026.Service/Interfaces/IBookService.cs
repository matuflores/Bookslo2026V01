using Bookslo2026.Service.DTOs.Book;
using Bookslo2026.Service.DTOs.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Interfaces
{
    public interface IBookService
    {
        List<BookListDto> GetAll();
        (bool Success, List<string> Errors) Add(BookCreateDto book);
        (bool Success, List<string> Errors) Delete(int id);
        BookDetailsDto? GetById(int id);

        //PublisherUpdateDto? GetForUpdate(int id);

        //(bool Success, List<string> Errors) Update(PublisherUpdateDto publisher);
    }
}

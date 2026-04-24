using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Book;
using Bookslo2026.Service.DTOs.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Mappers
{
    public static class BookMapper
    {
        public static BookListDto ToBookListDto(Book book)
        {
            return new BookListDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublisherId = book.PublisherId,
                PublishedDate = book.PublishedDate,
                Price = book.Price
            };
        }

        public static Book toEntity(BookCreateDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                AuthorId = bookDto.AuthorId,
                PublisherId = bookDto.PublisherId,
                PublishedDate = bookDto.PublishedDate,
                Price = bookDto.Price
            };
        }

        public static BookDetailsDto ToBookDetailsDto(Book book)
        {
            return new BookDetailsDto
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                PublisherId = book.PublisherId,
                PublishedDate = book.PublishedDate,
                Price = book.Price
            };
        }
    }
}

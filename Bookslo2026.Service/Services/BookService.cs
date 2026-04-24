using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Book;
using Bookslo2026.Service.DTOs.Publisher;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository? _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBooksRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public (bool Success, List<string> Errors) Add(BookCreateDto bookDto)
        {
            var book = BookMapper.toEntity(bookDto);
            try
            {
                _repository.Add(book);
                _unitOfWork.Save();
                return (true, new List<string>());
            }
            catch (Exception)
            {
                return (false, new List<string>() { "Database error!" });
            }
        }

        public (bool Success, List<string> Errors) Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _unitOfWork.Save();
                return (true, new List<string>());
            }
            catch (Exception)
            {
                return (false, new List<string>() { "Database error!" });
            }
        }

        public List<BookListDto> GetAll()
        {
            return _repository.GetAll()
                .Select(b => BookMapper
                .ToBookListDto(b))
                .ToList();
        }

        public BookDetailsDto? GetById(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return null;
            return BookMapper.ToBookDetailsDto(book);
        }

        public BookUpdateDto? GetForUpdate(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return null;
            return BookMapper.ToBookUpdateDto(book);
        }

        public (bool Success, List<string> Errors) Update(BookUpdateDto bookDto)
        {
            Book? book = _repository.GetById(bookDto.BookId);
            if (book == null)
            {
                    return (false, new List<string>() { "Book Not Found!" });
            }
            book.Title = bookDto.Title;
            book.AuthorId = bookDto.AuthorId;
            book.PublisherId = bookDto.PublisherId;
            book.PublishedDate = bookDto.PublishedDate;
            book.Price = bookDto.Price;
            
            if (!_repository.Exist(book.Title, book.AuthorId, book.PublisherId, book.BookId))
            {
                try
                {
                    _unitOfWork.Save();
                    return (true, new List<string>());
                }
                catch (Exception)
                {
                    return (false, new List<string>() { "Database error!" });
                }
            }
            else
            {
                return (false, new List<string>() { "Book already exist!" });
            }
        }
    }
}

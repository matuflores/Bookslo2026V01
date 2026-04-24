using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Service.DTOs.Book;
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
        public List<BookListDto> GetAll()
        {
            return _repository.GetAll()
                .Select(b => BookMapper
                .ToBookListDto(b))
                .ToList();
        }
    }
}

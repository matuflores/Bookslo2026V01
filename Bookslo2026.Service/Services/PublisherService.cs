using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Publisher;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Mappers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Services
{
    public class PublisherService : IPublisherService
    {

        private readonly IPublishersRepository? _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PublisherService(IPublishersRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public List<PublisherListDto> GetAll()
        {
            return _repository.GetAll()
                .Select(p => PublisherMapper
                .ToPublisherListDto(p))
                .ToList();
        }
    }
}

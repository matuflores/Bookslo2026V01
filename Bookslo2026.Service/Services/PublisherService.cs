using Bookslo2026.Data;
using Bookslo2026.Data.Interfaces;
using Bookslo2026.Service.DTOs.Publisher;
using Bookslo2026.Service.Interfaces;
using Bookslo2026.Service.Mappers;

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

        public (bool Success, List<string> Errors) Add(PublisherCreateDto publisherDto)
        {

            var publisher = PublisherMapper.toEntity(publisherDto);
            try
            {
                _repository.Add(publisher);
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

        public List<PublisherListDto> GetAll()
        {
            return _repository.GetAll()
                .Select(p => PublisherMapper
                .ToPublisherListDto(p))
                .ToList();
        }

        public PublisherDetailsDto? GetById(int id)
        {
            var publisher = _repository.GetById(id);
            if (publisher == null) return null;
            return PublisherMapper.ToPublisherDetailsDto(publisher);
        }
    }
}

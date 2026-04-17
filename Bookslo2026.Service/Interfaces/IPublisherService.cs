using Bookslo2026.Service.DTOs.Author;
using Bookslo2026.Service.DTOs.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Interfaces
{
    public interface IPublisherService
    {
        List<PublisherListDto> GetAll();
        (bool Success, List<string> Errors) Add(PublisherCreateDto publisher);
        (bool Success, List<string> Errors) Delete(int id);
        PublisherDetailsDto? GetById(int id);
    }
}

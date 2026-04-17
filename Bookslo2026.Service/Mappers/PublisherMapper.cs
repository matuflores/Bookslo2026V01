using Bookslo2026.Entities;
using Bookslo2026.Service.DTOs.Author;
using Bookslo2026.Service.DTOs.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.Mappers
{
    public static class PublisherMapper
    {
        public static PublisherListDto ToPublisherListDto(Publisher publisher)
        {
            return new PublisherListDto
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
                Country= publisher.Country,
            };
        }
    }
}

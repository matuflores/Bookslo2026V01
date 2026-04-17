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

        public static Publisher toEntity(PublisherCreateDto publisherDto)
        {
            return new Publisher
            {
                Name = publisherDto.Name,
                Country = publisherDto.Country,
                FoundedDate = publisherDto.FoundedDate,
                Email = publisherDto.Email
            };
        }

        public static PublisherDetailsDto ToPublisherDetailsDto(Publisher publisher)
        {
            return new PublisherDetailsDto
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
                Country = publisher.Country
            };
        }

        public static PublisherUpdateDto ToPublisherUpdateDto(Publisher publisher)
        {
            return new PublisherUpdateDto
            {
                PublisherId = publisher.PublisherId,
                Name = publisher.Name,
                Country = publisher.Country,
                FoundedDate= publisher.FoundedDate,
                Email = publisher.Email
            };
        }

        public static Publisher toEntity(PublisherUpdateDto publisherDto)
        {
            return new Publisher
            {
                PublisherId = publisherDto.PublisherId,
                Name = publisherDto.Name,
                Country = publisherDto.Country,
                FoundedDate = publisherDto.FoundedDate,
                Email = publisherDto.Email
            };
        }
    }
}

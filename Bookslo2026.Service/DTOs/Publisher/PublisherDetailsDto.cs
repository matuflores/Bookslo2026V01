using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.DTOs.Publisher
{
    public class PublisherDetailsDto
    {
        public int PublisherId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}

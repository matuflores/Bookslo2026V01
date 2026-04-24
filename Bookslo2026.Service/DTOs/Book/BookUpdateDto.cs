using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.DTOs.Book
{
    public class BookUpdateDto
    {
        public int BookId { get; set; }
        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public DateTime PublishedDate { get; set; }

        public decimal Price { get; set; }
    }
}

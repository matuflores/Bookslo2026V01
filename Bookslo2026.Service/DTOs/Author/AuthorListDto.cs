using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Service.DTOs.Author
{
    public class AuthorListDto
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bookslo2026.Entities
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime FoundedDate { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{Name} - ({Country}) - Founded: {FoundedDate.ToShortDateString()} - {Email} - Active: {IsActive}";
        }

        ICollection<Book> Books { get; set; } = null!;
    }
}

using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookslo2026.Data.Configurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {//esta clase me permite configurar la entidad Author sin ensuciar mi entidad.
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasIndex(a => new { a.FirstName, a.LastName })
                .IsUnique().HasDatabaseName("IX_Authors_FirstName_LastName");

            builder.Property(a => a.FirstName)
                .IsRequired().HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired().HasMaxLength(50);

            builder.HasData(
                new Author { AuthorId = 1, FirstName = "Isaac", LastName = "Asimov" },
                new Author { AuthorId = 2, FirstName = "J.K.", LastName = "Rowling" },
                new Author { AuthorId = 3, FirstName = "George", LastName = "Orwell" },
                new Author { AuthorId = 4, FirstName = "Jane", LastName = "Austen" }
                );
        }
    }
}

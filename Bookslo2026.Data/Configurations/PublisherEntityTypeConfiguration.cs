
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookslo2026.Data.Configurations
{
    public class PublisherEntityTypeConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            //builder.ToTable("Publishers");
            //builder.HasKey(p => p.PublisherId);
            builder.HasData(
                new Publisher { PublisherId = 1, Name = "Editorial Ateneo", Country = "Argentina", FoundedDate = new DateTime(1912, 5, 10), Email = "contacto@ateneo.com", IsActive = true },
                new Publisher { PublisherId = 2, Name = "Planeta", Country = "España", FoundedDate = new DateTime(1949, 1, 1), Email = "info@planeta.es", IsActive = true },
                new Publisher { PublisherId = 3, Name = "Siglo XXI", Country = "México", FoundedDate = new DateTime(1965, 11, 15), Email = "ventas@sigloxxi.mx", IsActive = true },
                new Publisher { PublisherId = 4, Name = "Sudamericana", Country = "Argentina", FoundedDate = new DateTime(1939, 7, 1), Email = "admin@sudamericana.com.ar", IsActive = true }
                );
        }
    }
}

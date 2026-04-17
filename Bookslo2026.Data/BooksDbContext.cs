using Bookslo2026.Data.Configurations;
using Bookslo2026.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bookslo2026.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }//agrego referencia de la tabla de author
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BooksIo2026; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        //creo la base de datos desde el ccodigo "consola del administrador de paquetes" y el comando "add-migration InitialCreate" 
        //para que funcionen tengo que instalar el paquete "Microsoft.EntityFrameworkCore.Tools" en el proyecto de data
        //en proyecto determinado tengo que apuntar para el proyecto de data
        //para que la migracion se cree e impacte en la base de datos tengo que poner en comando "update-database" y luego el nombre de la migracion "InitialCreate"

        //ahora le voy decirle al contexto que cargue las definiciones de la entidad (.Data --> Configurations)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BooksDbContext).Assembly);//esta linea hace lo mismo que la anterior, pero es mas generica, busca todas las clases que implementen la interfaz IEntityTypeConfiguration y las aplica
        }
    }
}

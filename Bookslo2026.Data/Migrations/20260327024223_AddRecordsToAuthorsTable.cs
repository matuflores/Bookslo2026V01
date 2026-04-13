using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookslo2026.Data.Migrations
{
    
    /// <inheritdoc />
    public partial class AddRecordsToAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Authors (FirstName, LastName) VALUES ('Lionel', 'Messi')");
            migrationBuilder.Sql("INSERT INTO Authors (FirstName, LastName) VALUES ('Ronaldinho', 'Gaucho')");
            migrationBuilder.Sql("INSERT INTO Authors (FirstName, LastName) VALUES ('Thierry', 'Henry')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE * FROM Authors");
        }
        //luego de hacer esto pongo update-database y efectuo la carga
    }
}

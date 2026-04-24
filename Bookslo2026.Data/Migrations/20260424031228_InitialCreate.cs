using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookslo2026.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Isaac", "Asimov" },
                    { 2, "J.K.", "Rowling" },
                    { 3, "George", "Orwell" },
                    { 4, "Jane", "Austen" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Country", "Email", "FoundedDate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "Argentina", "contacto@ateneo.com", new DateTime(1912, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Editorial Ateneo" },
                    { 2, "España", "info@planeta.es", new DateTime(1949, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Planeta" },
                    { 3, "México", "ventas@sigloxxi.mx", new DateTime(1965, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Siglo XXI" },
                    { 4, "Argentina", "admin@sudamericana.com.ar", new DateTime(1939, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sudamericana" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "IsActive", "Price", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, true, 15000m, new DateTime(1951, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Foundation" },
                    { 2, 2, true, 18000m, new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Dune" },
                    { 3, 3, true, 17000m, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "2001: A Space Odyssey" },
                    { 4, 4, true, 16000m, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Do Androids Dream of Electric Sheep?" },
                    { 5, 1, true, 14000m, new DateTime(1953, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fahrenheit 451" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FirstName_LastName",
                table: "Authors",
                columns: new[] { "FirstName", "LastName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title_AuthorId",
                table: "Books",
                columns: new[] { "Title", "AuthorId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}

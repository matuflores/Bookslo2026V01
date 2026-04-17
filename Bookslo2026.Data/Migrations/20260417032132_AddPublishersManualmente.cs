using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookslo2026.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPublishersManualmente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "PublisherId",
                keyValue: 4);
        }
    }
}

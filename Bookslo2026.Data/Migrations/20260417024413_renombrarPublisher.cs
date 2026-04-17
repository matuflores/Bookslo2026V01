using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookslo2026.Data.Migrations
{
    /// <inheritdoc />
    public partial class renombrarPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_publishers",
                table: "publishers");

            migrationBuilder.RenameTable(
                name: "publishers",
                newName: "Publishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "publishers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_publishers",
                table: "publishers",
                column: "PublisherId");
        }
    }
}

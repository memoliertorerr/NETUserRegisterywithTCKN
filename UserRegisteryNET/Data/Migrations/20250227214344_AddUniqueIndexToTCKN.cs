using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegisteryNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToTCKN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_TCKN",
                table: "Users",
                column: "TCKN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TCKN",
                table: "Users");
        }
    }
}

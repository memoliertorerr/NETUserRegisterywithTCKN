using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserRegisteryNET.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TCKN = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "LastName", "Name", "Password", "TCKN" },
                values: new object[,]
                {
                    { 1, "lastName1", "name1", "password_1_123", "12345678911" },
                    { 2, "lastName2", "name2", "password_2_123", "12345678912" },
                    { 3, "lastName3", "name3", "password_3_123", "12345678913" },
                    { 4, "lastName4", "name4", "password_4_123", "12345678914" },
                    { 5, "lastName5", "name5", "password_5_123", "12345678915" },
                    { 6, "lastName6", "name6", "password_6_123", "12345678916" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

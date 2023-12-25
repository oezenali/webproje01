using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webproje1.Migrations
{
    /// <inheritdoc />
    public partial class guncelleme03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uretici",
                table: "Yelekler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uretici",
                table: "Yaglar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uretici",
                table: "Receller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uretici",
                table: "Ekmekler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uretici",
                table: "Baharatlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uretici",
                table: "Yelekler");

            migrationBuilder.DropColumn(
                name: "Uretici",
                table: "Yaglar");

            migrationBuilder.DropColumn(
                name: "Uretici",
                table: "Receller");

            migrationBuilder.DropColumn(
                name: "Uretici",
                table: "Ekmekler");

            migrationBuilder.DropColumn(
                name: "Uretici",
                table: "Baharatlar");
        }
    }
}

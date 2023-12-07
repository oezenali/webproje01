using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webproje1.Migrations
{
    /// <inheritdoc />
    public partial class Guncelleme01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UretimTarihi",
                table: "Yelekler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UretimTarihi",
                table: "Yaglar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UretimTarihi",
                table: "Baharatlar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UretimTarihi",
                table: "Yelekler");

            migrationBuilder.DropColumn(
                name: "UretimTarihi",
                table: "Yaglar");

            migrationBuilder.DropColumn(
                name: "UretimTarihi",
                table: "Baharatlar");
        }
    }
}

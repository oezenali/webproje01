using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webproje1.Migrations
{
    /// <inheritdoc />
    public partial class calisan02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Calisanlar",
                newName: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Calisanlar",
                newName: "Salary");
        }
    }
}

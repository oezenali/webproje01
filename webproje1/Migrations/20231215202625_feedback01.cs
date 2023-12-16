using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webproje1.Migrations
{
    /// <inheritdoc />
    public partial class feedback01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CalisanLar",
                table: "CalisanLar");

            migrationBuilder.RenameTable(
                name: "CalisanLar",
                newName: "Calisanlar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Feedbackler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbackler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbackler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calisanlar",
                table: "Calisanlar");

            migrationBuilder.RenameTable(
                name: "Calisanlar",
                newName: "CalisanLar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalisanLar",
                table: "CalisanLar",
                column: "Id");
        }
    }
}

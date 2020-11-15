using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_mega_hack_5.Migrations
{
    public partial class UrlImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Cliente");
        }
    }
}

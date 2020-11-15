using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_mega_hack_5.Migrations
{
    public partial class Login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Cliente");
        }
    }
}

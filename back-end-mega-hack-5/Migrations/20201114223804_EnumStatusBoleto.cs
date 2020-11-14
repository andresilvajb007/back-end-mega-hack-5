using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end_mega_hack_5.Migrations
{
    public partial class EnumStatusBoleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumStatusBoleto",
                table: "Boleto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumStatusBoleto",
                table: "Boleto");
        }
    }
}

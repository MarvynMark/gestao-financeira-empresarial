using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class EdicaoEmAlgumasPropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ValorVendido",
                table: "ItensVenda",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorVendido",
                table: "ItensVenda");
        }
    }
}

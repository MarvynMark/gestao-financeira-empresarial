using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class AddColunaPrecoMaoDeObra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PrecoMaoDeObra",
                table: "ProdutosEstoque",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItensVenda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoMaoDeObra",
                table: "ProdutosEstoque");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItensVenda");
        }
    }
}

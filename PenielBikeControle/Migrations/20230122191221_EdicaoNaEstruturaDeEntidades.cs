using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class EdicaoNaEstruturaDeEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProdutoEstoqueEntregue",
                table: "Vendas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VendaPaga",
                table: "Vendas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoClienteId",
                table: "ItensVenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProdutosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_ProdutoClienteId",
                table: "ItensVenda",
                column: "ProdutoClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosCliente_ClienteId",
                table: "ProdutosCliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_ProdutosCliente_ProdutoClienteId",
                table: "ItensVenda",
                column: "ProdutoClienteId",
                principalTable: "ProdutosCliente",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_ProdutosCliente_ProdutoClienteId",
                table: "ItensVenda");

            migrationBuilder.DropTable(
                name: "ProdutosCliente");

            migrationBuilder.DropIndex(
                name: "IX_ItensVenda_ProdutoClienteId",
                table: "ItensVenda");

            migrationBuilder.DropColumn(
                name: "ProdutoEstoqueEntregue",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "VendaPaga",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutoClienteId",
                table: "ItensVenda");
        }
    }
}

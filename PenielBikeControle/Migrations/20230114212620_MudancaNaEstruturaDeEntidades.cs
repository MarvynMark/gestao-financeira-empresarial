using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class MudancaNaEstruturaDeEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_TipoItemVenda_TipoItemVendaId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Vendas_VendaId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Cliente_ClienteId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedor_VendedorId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "TipoItemVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ItemVenda");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "ItemVenda");

            migrationBuilder.RenameTable(
                name: "Vendedor",
                newName: "Vendedores");

            migrationBuilder.RenameTable(
                name: "ItemVenda",
                newName: "ItensVenda");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "TipoItemVendaId",
                table: "ItensVenda",
                newName: "ProdutoEstoqueId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_VendaId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_TipoItemVendaId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_ProdutoEstoqueId");

            migrationBuilder.AddColumn<double>(
                name: "DescontoTotal",
                table: "Vendas",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TiposProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProduto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutosEstoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marca = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoCusto = table.Column<double>(type: "double", nullable: false),
                    PrecoFinal = table.Column<double>(type: "double", nullable: false),
                    QtdeEmEstoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutosEstoque_TiposProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TiposProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEstoque_TipoProdutoId",
                table: "ProdutosEstoque",
                column: "TipoProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_ProdutosEstoque_ProdutoEstoqueId",
                table: "ItensVenda",
                column: "ProdutoEstoqueId",
                principalTable: "ProdutosEstoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_ProdutosEstoque_ProdutoEstoqueId",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Vendas_VendaId",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Vendedores_VendedorId",
                table: "Vendas");

            migrationBuilder.DropTable(
                name: "ProdutosEstoque");

            migrationBuilder.DropTable(
                name: "TiposProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendedores",
                table: "Vendedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DescontoTotal",
                table: "Vendas");

            migrationBuilder.RenameTable(
                name: "Vendedores",
                newName: "Vendedor");

            migrationBuilder.RenameTable(
                name: "ItensVenda",
                newName: "ItemVenda");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "ProdutoEstoqueId",
                table: "ItemVenda",
                newName: "TipoItemVendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_VendaId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_VendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_ProdutoEstoqueId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_TipoItemVendaId");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "ItemVenda",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "ItemVenda",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ItemVenda",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "ItemVenda",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendedor",
                table: "Vendedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipoItemVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoItemVenda", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_TipoItemVenda_TipoItemVendaId",
                table: "ItemVenda",
                column: "TipoItemVendaId",
                principalTable: "TipoItemVenda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Vendas_VendaId",
                table: "ItemVenda",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Cliente_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Vendedor_VendedorId",
                table: "Vendas",
                column: "VendedorId",
                principalTable: "Vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

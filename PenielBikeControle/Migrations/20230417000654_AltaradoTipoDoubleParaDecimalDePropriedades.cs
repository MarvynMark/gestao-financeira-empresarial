using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class AltaradoTipoDoubleParaDecimalDePropriedades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DescontoTotal",
                table: "Vendas",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoMaoDeObra",
                table: "ProdutosEstoque",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoFinal",
                table: "ProdutosEstoque",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoCusto",
                table: "ProdutosEstoque",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorVendido",
                table: "ItensVenda",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DescontoTotal",
                table: "Vendas",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoMaoDeObra",
                table: "ProdutosEstoque",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoFinal",
                table: "ProdutosEstoque",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PrecoCusto",
                table: "ProdutosEstoque",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "ValorVendido",
                table: "ItensVenda",
                type: "double",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");
        }
    }
}

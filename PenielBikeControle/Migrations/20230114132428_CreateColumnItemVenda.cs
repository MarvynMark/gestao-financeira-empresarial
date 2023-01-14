using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PenielBikeControle.Migrations
{
    public partial class CreateColumnItemVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ItemVenda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ItemVenda");
        }
    }
}

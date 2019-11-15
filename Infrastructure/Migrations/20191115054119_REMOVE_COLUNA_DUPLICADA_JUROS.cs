using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class REMOVE_COLUNA_DUPLICADA_JUROS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JurosCompostos",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "JurosSimples",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "Parcelas",
                table: "Compra");

            migrationBuilder.AddColumn<decimal>(
                name: "Juros",
                table: "Compra",
                type: "decimal(15, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeParcela",
                table: "Compra",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Juros",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "QuantidadeParcela",
                table: "Compra");

            migrationBuilder.AddColumn<decimal>(
                name: "JurosCompostos",
                table: "Compra",
                type: "decimal(15, 4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JurosSimples",
                table: "Compra",
                type: "decimal(15, 4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Parcelas",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ALTERA_TIPO_COLUNAS_DECIMAIS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Compra",
                type: "decimal(15, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "JurosSimples",
                table: "Compra",
                type: "decimal(15, 4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "JurosCompostos",
                table: "Compra",
                type: "decimal(15, 4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(4, 4)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Compra",
                type: "decimal(4, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "JurosSimples",
                table: "Compra",
                type: "decimal(4, 4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15, 4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "JurosCompostos",
                table: "Compra",
                type: "decimal(4, 4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(15, 4)",
                oldNullable: true);
        }
    }
}

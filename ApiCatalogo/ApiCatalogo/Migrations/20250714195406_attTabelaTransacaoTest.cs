using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class attTabelaTransacaoTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 54, 6, 263, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 54, 6, 263, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 54, 6, 263, DateTimeKind.Local).AddTicks(4402));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Transacoes");

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 15, 32, 2, 553, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 15, 32, 2, 553, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 15, 32, 2, 553, DateTimeKind.Local).AddTicks(1826));
        }
    }
}

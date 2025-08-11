using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class attFieldValorTableTransacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 17, 36, 12, 524, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 17, 36, 12, 524, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 17, 36, 12, 524, DateTimeKind.Local).AddTicks(7233));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 59, 35, 620, DateTimeKind.Local).AddTicks(5917));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 59, 35, 620, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2025, 7, 14, 16, 59, 35, 620, DateTimeKind.Local).AddTicks(5922));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookApi.Migrations
{
    /// <inheritdoc />
    public partial class corrigindo_m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genero_Editoras_EditoraId",
                table: "Genero");

            migrationBuilder.DropForeignKey(
                name: "FK_Genero_Genero_GeneroId",
                table: "Genero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Genero_EditoraId",
                table: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Genero_GeneroId",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "EditoraId",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Genero");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Nacionalidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    AnoPublicacao = table.Column<DateOnly>(type: "date", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    EdidoraId = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Editoras_EdidoraId",
                        column: x => x.EdidoraId,
                        principalTable: "Editoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorId",
                table: "Livros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EdidoraId",
                table: "Livros",
                column: "EdidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_GeneroId",
                table: "Livros",
                column: "GeneroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.AddColumn<int>(
                name: "EditoraId",
                table: "Genero",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Genero",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_EditoraId",
                table: "Genero",
                column: "EditoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_GeneroId",
                table: "Genero",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_Editoras_EditoraId",
                table: "Genero",
                column: "EditoraId",
                principalTable: "Editoras",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_Genero_GeneroId",
                table: "Genero",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id");
        }
    }
}

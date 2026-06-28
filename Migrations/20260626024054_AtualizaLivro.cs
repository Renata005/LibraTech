using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraTech.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Livros",
                newName: "Sinopse");

            migrationBuilder.AddColumn<string>(
                name: "CapaUrl",
                table: "Livros",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Livros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Livros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Livros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CategoriaId",
                table: "Livros",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Livros_Categorias_CategoriaId",
                table: "Livros",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livros_Categorias_CategoriaId",
                table: "Livros");

            migrationBuilder.DropIndex(
                name: "IX_Livros_CategoriaId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "CapaUrl",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Livros");

            migrationBuilder.RenameColumn(
                name: "Sinopse",
                table: "Livros",
                newName: "Categoria");
        }
    }
}

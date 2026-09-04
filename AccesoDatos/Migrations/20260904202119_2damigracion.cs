using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class _2damigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Libro",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "autorId",
                table: "Libro",
                newName: "AutorId");

            migrationBuilder.RenameColumn(
                name: "aniopublicacion",
                table: "Libro",
                newName: "AnioPublicacion");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Libro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Categoria_CategoriaId",
                table: "Libro");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Libro_AutorId",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_CategoriaId",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Libro",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Libro",
                newName: "autorId");

            migrationBuilder.RenameColumn(
                name: "AnioPublicacion",
                table: "Libro",
                newName: "aniopublicacion");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirrasBares.Migrations
{
    /// <inheritdoc />
    public partial class AddMarcasCervezas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Cervezas");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "Cervezas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SitioWeb = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cervezas_MarcaId",
                table: "Cervezas",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cervezas_Marcas_MarcaId",
                table: "Cervezas",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cervezas_Marcas_MarcaId",
                table: "Cervezas");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropIndex(
                name: "IX_Cervezas_MarcaId",
                table: "Cervezas");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "Cervezas");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Cervezas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

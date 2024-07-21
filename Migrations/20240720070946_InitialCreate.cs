using System;
using BirrasBares.Utilities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirrasBares.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTableIfExists("HorariosBar", "dbo");
            migrationBuilder.DropTableIfExists("PlatosMenu", "dbo");
            migrationBuilder.DropTableIfExists("BaresCervezas", "dbo");
            migrationBuilder.DropTableIfExists("Eventos", "dbo");
            migrationBuilder.DropTableIfExists("Bares", "dbo");
            migrationBuilder.DropTableIfExists("Cervezas", "dbo");


            migrationBuilder.CreateTable(
                name: "Bares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SitioWeb = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    AñoApertura = table.Column<int>(type: "int", nullable: false),
                    TipoBar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TieneTerraza = table.Column<bool>(type: "bit", nullable: false),
                    PermiteReservas = table.Column<bool>(type: "bit", nullable: false),
                    ServiciosAdicionales = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ambiente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RangoPrecios = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CalificacionPromedio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RedesSociales = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccesibilidadDiscapacitados = table.Column<bool>(type: "bit", nullable: false),
                    Especialidades = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cervezas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estilo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Graduacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IBU = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AñoLanzamiento = table.Column<int>(type: "int", nullable: true),
                    Calorias = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aroma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sabor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Maridaje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EsArtesanal = table.Column<bool>(type: "bit", nullable: false),
                    DisponibleTodoElAño = table.Column<bool>(type: "bit", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cervezas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    BarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Bares_BarId",
                        column: x => x.BarId,
                        principalTable: "Bares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorariosBar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosBar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorariosBar_Bares_BarId",
                        column: x => x.BarId,
                        principalTable: "Bares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatosMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EsVegano = table.Column<bool>(type: "bit", nullable: false),
                    EsVegetariano = table.Column<bool>(type: "bit", nullable: false),
                    EsSinGluten = table.Column<bool>(type: "bit", nullable: false),
                    Alergenos = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ingredientes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Calorias = table.Column<int>(type: "int", nullable: true),
                    TamañoPorcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EsEspecialidad = table.Column<bool>(type: "bit", nullable: false),
                    Temporada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Popularidad = table.Column<int>(type: "int", nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatosMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlatosMenu_Bares_BarId",
                        column: x => x.BarId,
                        principalTable: "Bares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaresCervezas",
                columns: table => new
                {
                    BarId = table.Column<int>(type: "int", nullable: false),
                    CervezaId = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaresCervezas", x => new { x.BarId, x.CervezaId });
                    table.ForeignKey(
                        name: "FK_BaresCervezas_Bares_BarId",
                        column: x => x.BarId,
                        principalTable: "Bares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaresCervezas_Cervezas_CervezaId",
                        column: x => x.CervezaId,
                        principalTable: "Cervezas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaresCervezas_CervezaId",
                table: "BaresCervezas",
                column: "CervezaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_BarId",
                table: "Eventos",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_HorariosBar_BarId",
                table: "HorariosBar",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatosMenu_BarId",
                table: "PlatosMenu",
                column: "BarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaresCervezas");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "HorariosBar");

            migrationBuilder.DropTable(
                name: "PlatosMenu");

            migrationBuilder.DropTable(
                name: "Cervezas");

            migrationBuilder.DropTable(
                name: "Bares");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirrasBares.Migrations
{
    /// <inheritdoc />
    public partial class EventoModelUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicio",
                table: "Eventos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFin",
                table: "Eventos",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Eventos",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Eventos");
        }
    }
}

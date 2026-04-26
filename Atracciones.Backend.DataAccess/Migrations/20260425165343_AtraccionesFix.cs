using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AtraccionesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_HORARIO_slot",
                table: "HORARIO");

            migrationBuilder.DropColumn(
                name: "tck_capacidad_maxima",
                table: "TICKET");

            migrationBuilder.DropColumn(
                name: "tck_cupos_disponibles",
                table: "TICKET");

            migrationBuilder.DropColumn(
                name: "tck_id",
                table: "HORARIO");

            migrationBuilder.DropColumn(
                name: "at_calificacion",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_cupos_disponibles",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_disponible",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_disponible_manana",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_proxima_fecha_disponible",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_total_resenias",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "total_idiomas",
                table: "ATRACCION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tck_capacidad_maxima",
                table: "TICKET",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tck_cupos_disponibles",
                table: "TICKET",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tck_id",
                table: "HORARIO",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "at_calificacion",
                table: "ATRACCION",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "at_cupos_disponibles",
                table: "ATRACCION",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "at_disponible",
                table: "ATRACCION",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "at_disponible_manana",
                table: "ATRACCION",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "at_proxima_fecha_disponible",
                table: "ATRACCION",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "at_total_resenias",
                table: "ATRACCION",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_idiomas",
                table: "ATRACCION",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "UK_HORARIO_slot",
                table: "HORARIO",
                columns: new[] { "tck_id", "hor_fecha", "hor_hora_inicio" },
                unique: true);
        }
    }
}

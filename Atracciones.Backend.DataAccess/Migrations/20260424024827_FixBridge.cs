using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixBridge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ai_fecha_eliminacion",
                table: "ATRACCION_INCLUYE");

            migrationBuilder.DropColumn(
                name: "ai_fecha_ingreso",
                table: "ATRACCION_INCLUYE");

            migrationBuilder.DropColumn(
                name: "ai_usuario_eliminacion",
                table: "ATRACCION_INCLUYE");

            migrationBuilder.DropColumn(
                name: "ai_usuario_ingreso",
                table: "ATRACCION_INCLUYE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ai_fecha_eliminacion",
                table: "ATRACCION_INCLUYE",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ai_fecha_ingreso",
                table: "ATRACCION_INCLUYE",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ai_usuario_eliminacion",
                table: "ATRACCION_INCLUYE",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ai_usuario_ingreso",
                table: "ATRACCION_INCLUYE",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}

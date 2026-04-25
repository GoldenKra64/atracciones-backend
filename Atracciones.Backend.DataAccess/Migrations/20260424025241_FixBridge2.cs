using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixBridge2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IDIOMA_ATRACCION_ATRACCION_AtId",
                table: "IDIOMA_ATRACCION");

            migrationBuilder.DropForeignKey(
                name: "FK_IDIOMA_ATRACCION_IDIOMA_IdId",
                table: "IDIOMA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ca_estado",
                table: "CATEGORIA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ca_fecha_eliminacion",
                table: "CATEGORIA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ca_fecha_ingreso",
                table: "CATEGORIA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ca_usuario_eliminacion",
                table: "CATEGORIA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ca_usuario_ingreso",
                table: "CATEGORIA_ATRACCION");

            migrationBuilder.DropColumn(
                name: "ai_estado",
                table: "ATRACCION_INCLUYE");

            migrationBuilder.RenameColumn(
                name: "AtId",
                table: "IDIOMA_ATRACCION",
                newName: "at_id");

            migrationBuilder.RenameColumn(
                name: "IdId",
                table: "IDIOMA_ATRACCION",
                newName: "id_id");

            migrationBuilder.RenameIndex(
                name: "IX_IDIOMA_ATRACCION_AtId",
                table: "IDIOMA_ATRACCION",
                newName: "IX_IDIOMA_ATRACCION_at_id");

            migrationBuilder.AddForeignKey(
                name: "FK_IDIOMA_ATRACCION_ATRACCION_at_id",
                table: "IDIOMA_ATRACCION",
                column: "at_id",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IDIOMA_ATRACCION_IDIOMA_id_id",
                table: "IDIOMA_ATRACCION",
                column: "id_id",
                principalTable: "IDIOMA",
                principalColumn: "id_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IDIOMA_ATRACCION_ATRACCION_at_id",
                table: "IDIOMA_ATRACCION");

            migrationBuilder.DropForeignKey(
                name: "FK_IDIOMA_ATRACCION_IDIOMA_id_id",
                table: "IDIOMA_ATRACCION");

            migrationBuilder.RenameColumn(
                name: "at_id",
                table: "IDIOMA_ATRACCION",
                newName: "AtId");

            migrationBuilder.RenameColumn(
                name: "id_id",
                table: "IDIOMA_ATRACCION",
                newName: "IdId");

            migrationBuilder.RenameIndex(
                name: "IX_IDIOMA_ATRACCION_at_id",
                table: "IDIOMA_ATRACCION",
                newName: "IX_IDIOMA_ATRACCION_AtId");

            migrationBuilder.AddColumn<string>(
                name: "ca_estado",
                table: "CATEGORIA_ATRACCION",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ca_fecha_eliminacion",
                table: "CATEGORIA_ATRACCION",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ca_fecha_ingreso",
                table: "CATEGORIA_ATRACCION",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ca_usuario_eliminacion",
                table: "CATEGORIA_ATRACCION",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ca_usuario_ingreso",
                table: "CATEGORIA_ATRACCION",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ai_estado",
                table: "ATRACCION_INCLUYE",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_IDIOMA_ATRACCION_ATRACCION_AtId",
                table: "IDIOMA_ATRACCION",
                column: "AtId",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IDIOMA_ATRACCION_IDIOMA_IdId",
                table: "IDIOMA_ATRACCION",
                column: "IdId",
                principalTable: "IDIOMA",
                principalColumn: "id_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

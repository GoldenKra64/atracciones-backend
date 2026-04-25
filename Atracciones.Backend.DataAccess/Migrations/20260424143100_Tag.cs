using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Tag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AtMoneda",
                table: "ATRACCION",
                type: "text",
                nullable: true);

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
                name: "total_idiomas",
                table: "ATRACCION",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TAG",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tag_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "TAG_ATRACCION",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "integer", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG_ATRACCION", x => new { x.tag_id, x.at_id });
                    table.ForeignKey(
                        name: "FK_TAG_ATRACCION_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TAG_ATRACCION_TAG_tag_id",
                        column: x => x.tag_id,
                        principalTable: "TAG",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAG_ATRACCION_at_id",
                table: "TAG_ATRACCION",
                column: "at_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAG_ATRACCION");

            migrationBuilder.DropTable(
                name: "TAG");

            migrationBuilder.DropColumn(
                name: "AtMoneda",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_calificacion",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_cupos_disponibles",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_disponible_manana",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "at_proxima_fecha_disponible",
                table: "ATRACCION");

            migrationBuilder.DropColumn(
                name: "total_idiomas",
                table: "ATRACCION");
        }
    }
}

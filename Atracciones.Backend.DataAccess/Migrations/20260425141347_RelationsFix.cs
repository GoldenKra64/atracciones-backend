using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RelationsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESENIA_ATRACCION_at_id",
                table: "RESENIA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESENIA_CLIENTES_ClienteCliId",
                table: "RESENIA");

            migrationBuilder.DropIndex(
                name: "IX_RESENIA_ClienteCliId",
                table: "RESENIA");

            migrationBuilder.DropColumn(
                name: "ClienteCliId",
                table: "RESENIA");

            migrationBuilder.CreateTable(
                name: "NOINCLUYE",
                columns: table => new
                {
                    noinc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inc_descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    inc_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOINCLUYE", x => x.noinc_id);
                });

            migrationBuilder.CreateTable(
                name: "ATRACCION_NOINCLUYE",
                columns: table => new
                {
                    inc_id = table.Column<int>(type: "integer", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    AtraccionAtId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRACCION_NOINCLUYE", x => new { x.inc_id, x.at_id });
                    table.ForeignKey(
                        name: "FK_ATRACCION_NOINCLUYE_ATRACCION_AtraccionAtId",
                        column: x => x.AtraccionAtId,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id");
                    table.ForeignKey(
                        name: "FK_ATRACCION_NOINCLUYE_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATRACCION_NOINCLUYE_NOINCLUYE_inc_id",
                        column: x => x.inc_id,
                        principalTable: "NOINCLUYE",
                        principalColumn: "noinc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RESENIA_cli_id",
                table: "RESENIA",
                column: "cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_ATRACCION_NOINCLUYE_at_id",
                table: "ATRACCION_NOINCLUYE",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_ATRACCION_NOINCLUYE_AtraccionAtId",
                table: "ATRACCION_NOINCLUYE",
                column: "AtraccionAtId");

            migrationBuilder.AddForeignKey(
                name: "FK_RESENIA_ATRACCION_at_id",
                table: "RESENIA",
                column: "at_id",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RESENIA_CLIENTES_cli_id",
                table: "RESENIA",
                column: "cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESENIA_ATRACCION_at_id",
                table: "RESENIA");

            migrationBuilder.DropForeignKey(
                name: "FK_RESENIA_CLIENTES_cli_id",
                table: "RESENIA");

            migrationBuilder.DropTable(
                name: "ATRACCION_NOINCLUYE");

            migrationBuilder.DropTable(
                name: "NOINCLUYE");

            migrationBuilder.DropIndex(
                name: "IX_RESENIA_cli_id",
                table: "RESENIA");

            migrationBuilder.AddColumn<int>(
                name: "ClienteCliId",
                table: "RESENIA",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RESENIA_ClienteCliId",
                table: "RESENIA",
                column: "ClienteCliId");

            migrationBuilder.AddForeignKey(
                name: "FK_RESENIA_ATRACCION_at_id",
                table: "RESENIA",
                column: "at_id",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RESENIA_CLIENTES_ClienteCliId",
                table: "RESENIA",
                column: "ClienteCliId",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

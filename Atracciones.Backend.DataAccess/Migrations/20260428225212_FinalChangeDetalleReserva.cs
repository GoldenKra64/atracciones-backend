using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FinalChangeDetalleReserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RESERVA_DETALLE",
                table: "RESERVA_DETALLE");

            migrationBuilder.DropIndex(
                name: "IX_RESERVA_DETALLE_rev_id",
                table: "RESERVA_DETALLE");

            migrationBuilder.DropColumn(
                name: "rdet_id",
                table: "RESERVA_DETALLE");

            migrationBuilder.AlterColumn<string>(
                name: "cli_nombres",
                table: "CLIENTES",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cli_apellidos",
                table: "CLIENTES",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "at_estado",
                table: "ATRACCION",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "at_direccion",
                table: "ATRACCION",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RESERVA_DETALLE",
                table: "RESERVA_DETALLE",
                columns: new[] { "rev_id", "tck_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RESERVA_DETALLE",
                table: "RESERVA_DETALLE");

            migrationBuilder.AddColumn<int>(
                name: "rdet_id",
                table: "RESERVA_DETALLE",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "cli_nombres",
                table: "CLIENTES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "cli_apellidos",
                table: "CLIENTES",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "at_estado",
                table: "ATRACCION",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "at_direccion",
                table: "ATRACCION",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RESERVA_DETALLE",
                table: "RESERVA_DETALLE",
                column: "rdet_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_DETALLE_rev_id",
                table: "RESERVA_DETALLE",
                column: "rev_id");
        }
    }
}

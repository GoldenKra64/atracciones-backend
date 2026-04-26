using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReservasFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESERVAS_CLIENTES_cli_id",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "rev_origen_canal",
                table: "RESERVAS");

            migrationBuilder.RenameColumn(
                name: "rdet_titulo",
                table: "RESERVA_DETALLE",
                newName: "rdet_tipo_participante");

            migrationBuilder.RenameColumn(
                name: "rdet_cantidad",
                table: "RESERVA_DETALLE",
                newName: "TicCantidad");

            migrationBuilder.AlterColumn<double>(
                name: "rev_valor_iva",
                table: "RESERVAS",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "rev_total",
                table: "RESERVAS",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "rev_subtotal",
                table: "RESERVAS",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "cli_id",
                table: "RESERVAS",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "HorFecha",
                table: "RESERVAS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HorHoraFin",
                table: "RESERVAS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HorHoraInicio",
                table: "RESERVAS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevCanal",
                table: "RESERVAS",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "rdet_subtotal",
                table: "RESERVA_DETALLE",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "rdet_precio_unit",
                table: "RESERVA_DETALLE",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "TicTitulo",
                table: "RESERVA_DETALLE",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVAS_CLIENTES_cli_id",
                table: "RESERVAS",
                column: "cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RESERVAS_CLIENTES_cli_id",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "HorFecha",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "HorHoraFin",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "HorHoraInicio",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "RevCanal",
                table: "RESERVAS");

            migrationBuilder.DropColumn(
                name: "TicTitulo",
                table: "RESERVA_DETALLE");

            migrationBuilder.RenameColumn(
                name: "rdet_tipo_participante",
                table: "RESERVA_DETALLE",
                newName: "rdet_titulo");

            migrationBuilder.RenameColumn(
                name: "TicCantidad",
                table: "RESERVA_DETALLE",
                newName: "rdet_cantidad");

            migrationBuilder.AlterColumn<decimal>(
                name: "rev_valor_iva",
                table: "RESERVAS",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "rev_total",
                table: "RESERVAS",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "rev_subtotal",
                table: "RESERVAS",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<int>(
                name: "cli_id",
                table: "RESERVAS",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "rev_origen_canal",
                table: "RESERVAS",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "rdet_subtotal",
                table: "RESERVA_DETALLE",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<decimal>(
                name: "rdet_precio_unit",
                table: "RESERVA_DETALLE",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddForeignKey(
                name: "FK_RESERVAS_CLIENTES_cli_id",
                table: "RESERVAS",
                column: "cli_id",
                principalTable: "CLIENTES",
                principalColumn: "cli_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

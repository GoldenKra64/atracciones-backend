using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class HorarioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "usu_guid",
                table: "USUARIO",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "tck_guid",
                table: "TICKET",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "rol_guid",
                table: "ROLES",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "rev_guid",
                table: "RESERVAS",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "rdet_guid",
                table: "RESERVA_DETALLE",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "rsn_guid",
                table: "RESENIA",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "inc_guid",
                table: "INCLUYE",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "img_guid",
                table: "IMAGEN",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "id_guid",
                table: "IDIOMA",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "fac_guid",
                table: "FACTURAS",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "des_guid",
                table: "DESTINO",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "dfac_guid",
                table: "DATOS_FACTURACION",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "cli_guid",
                table: "CLIENTES",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "cat_guid",
                table: "CATEGORIA",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "log_registro_guid",
                table: "AUDITORIA_LOG",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "log_guid",
                table: "AUDITORIA_LOG",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "at_guid",
                table: "ATRACCION",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateTable(
                name: "HORARIO",
                columns: table => new
                {
                    hor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hor_guid = table.Column<string>(type: "text", nullable: false),
                    tck_id = table.Column<int>(type: "integer", nullable: false),
                    hor_fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hor_hora_inicio = table.Column<TimeSpan>(type: "interval", nullable: false),
                    hor_hora_fin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    hor_cupos_disponibles = table.Column<int>(type: "integer", nullable: false),
                    hor_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hor_usuario_ingreso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    hor_ip_ingreso = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    hor_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    hor_usuario_mod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    hor_ip_mod = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    hor_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    hor_usuario_eliminacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    hor_ip_eliminacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    hor_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIO", x => x.hor_id);
                    table.ForeignKey(
                        name: "FK_HORARIO_TICKET_tck_id",
                        column: x => x.tck_id,
                        principalTable: "TICKET",
                        principalColumn: "tck_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UK_HORARIO_guid",
                table: "HORARIO",
                column: "hor_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_HORARIO_slot",
                table: "HORARIO",
                columns: new[] { "tck_id", "hor_fecha", "hor_hora_inicio" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HORARIO");

            migrationBuilder.AlterColumn<Guid>(
                name: "usu_guid",
                table: "USUARIO",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "tck_guid",
                table: "TICKET",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "rol_guid",
                table: "ROLES",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "rev_guid",
                table: "RESERVAS",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "rdet_guid",
                table: "RESERVA_DETALLE",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "rsn_guid",
                table: "RESENIA",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "inc_guid",
                table: "INCLUYE",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "img_guid",
                table: "IMAGEN",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_guid",
                table: "IDIOMA",
                type: "uuid",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<Guid>(
                name: "fac_guid",
                table: "FACTURAS",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "des_guid",
                table: "DESTINO",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "dfac_guid",
                table: "DATOS_FACTURACION",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "cli_guid",
                table: "CLIENTES",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "cat_guid",
                table: "CATEGORIA",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "log_registro_guid",
                table: "AUDITORIA_LOG",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "log_guid",
                table: "AUDITORIA_LOG",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "at_guid",
                table: "ATRACCION",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

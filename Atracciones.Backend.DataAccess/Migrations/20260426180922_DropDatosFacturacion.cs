using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DropDatosFacturacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DATOS_FACTURACION");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DATOS_FACTURACION",
                columns: table => new
                {
                    dfac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fac_id = table.Column<int>(type: "integer", nullable: false),
                    dfac_apellido = table.Column<string>(type: "text", nullable: false),
                    dfac_correo = table.Column<string>(type: "text", nullable: false),
                    DfFechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dfac_guid = table.Column<string>(type: "text", nullable: false),
                    dfac_nombre = table.Column<string>(type: "text", nullable: false),
                    dfac_telefono = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DATOS_FACTURACION", x => x.dfac_id);
                    table.ForeignKey(
                        name: "FK_DATOS_FACTURACION_FACTURAS_fac_id",
                        column: x => x.fac_id,
                        principalTable: "FACTURAS",
                        principalColumn: "fac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DATOS_FACTURACION_fac_id",
                table: "DATOS_FACTURACION",
                column: "fac_id",
                unique: true);
        }
    }
}

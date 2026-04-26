using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TicketFixPorElAmorDeDios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKET_HORARIO_tck_id",
                table: "TICKET");

            migrationBuilder.AlterColumn<int>(
                name: "tck_id",
                table: "TICKET",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_hor_id",
                table: "TICKET",
                column: "hor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_TICKET_HORARIO_hor_id",
                table: "TICKET",
                column: "hor_id",
                principalTable: "HORARIO",
                principalColumn: "hor_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TICKET_HORARIO_hor_id",
                table: "TICKET");

            migrationBuilder.DropIndex(
                name: "IX_TICKET_hor_id",
                table: "TICKET");

            migrationBuilder.AlterColumn<int>(
                name: "tck_id",
                table: "TICKET",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_TICKET_HORARIO_tck_id",
                table: "TICKET",
                column: "tck_id",
                principalTable: "HORARIO",
                principalColumn: "hor_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

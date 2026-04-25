using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class HorarioTicketFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HORARIO_TICKET_tck_id",
                table: "HORARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_TICKET_ATRACCION_at_id",
                table: "TICKET");

            migrationBuilder.DropIndex(
                name: "IX_TICKET_at_id",
                table: "TICKET");

            migrationBuilder.RenameColumn(
                name: "at_id",
                table: "TICKET",
                newName: "hor_id");

            migrationBuilder.AlterColumn<int>(
                name: "tck_id",
                table: "TICKET",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "at_id",
                table: "HORARIO",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HORARIO_at_id",
                table: "HORARIO",
                column: "at_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HORARIO_ATRACCION_at_id",
                table: "HORARIO",
                column: "at_id",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TICKET_HORARIO_tck_id",
                table: "TICKET",
                column: "tck_id",
                principalTable: "HORARIO",
                principalColumn: "hor_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HORARIO_ATRACCION_at_id",
                table: "HORARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_TICKET_HORARIO_tck_id",
                table: "TICKET");

            migrationBuilder.DropIndex(
                name: "IX_HORARIO_at_id",
                table: "HORARIO");

            migrationBuilder.DropColumn(
                name: "at_id",
                table: "HORARIO");

            migrationBuilder.RenameColumn(
                name: "hor_id",
                table: "TICKET",
                newName: "at_id");

            migrationBuilder.AlterColumn<int>(
                name: "tck_id",
                table: "TICKET",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_at_id",
                table: "TICKET",
                column: "at_id");

            migrationBuilder.AddForeignKey(
                name: "FK_HORARIO_TICKET_tck_id",
                table: "HORARIO",
                column: "tck_id",
                principalTable: "TICKET",
                principalColumn: "tck_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TICKET_ATRACCION_at_id",
                table: "TICKET",
                column: "at_id",
                principalTable: "ATRACCION",
                principalColumn: "at_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

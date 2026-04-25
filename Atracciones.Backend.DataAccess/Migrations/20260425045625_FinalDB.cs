using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FinalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inc_guid",
                table: "INCLUYE");

            migrationBuilder.DropColumn(
                name: "id_guid",
                table: "IDIOMA");

            migrationBuilder.AlterColumn<string>(
                name: "id_descripcion",
                table: "IDIOMA",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "inc_guid",
                table: "INCLUYE",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "id_descripcion",
                table: "IDIOMA",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<string>(
                name: "id_guid",
                table: "IDIOMA",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

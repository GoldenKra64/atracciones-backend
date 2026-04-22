using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Atracciones.Backend.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AUDITORIA_LOG",
                columns: table => new
                {
                    log_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    log_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    log_tabla = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    log_operacion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    log_registro_id = table.Column<int>(type: "integer", nullable: true),
                    log_registro_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    log_datos_anteriores = table.Column<string>(type: "text", nullable: true),
                    log_datos_nuevos = table.Column<string>(type: "text", nullable: true),
                    log_fecha_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    log_usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    log_ip = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    log_origen_canal = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUDITORIA_LOG", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cat_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    cat_parent_id = table.Column<int>(type: "integer", nullable: true),
                    cat_nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    cat_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cat_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    cat_ip_ingreso = table.Column<string>(type: "text", nullable: false),
                    cat_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cat_usuario_mod = table.Column<string>(type: "text", nullable: true),
                    cat_ip_mod = table.Column<string>(type: "text", nullable: true),
                    cat_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cat_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    cat_ip_eliminacion = table.Column<string>(type: "text", nullable: true),
                    cat_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.cat_id);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_CATEGORIA_cat_parent_id",
                        column: x => x.cat_parent_id,
                        principalTable: "CATEGORIA",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DESTINO",
                columns: table => new
                {
                    des_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    des_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    des_nombre = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    des_pais = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    des_imagen_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    des_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    des_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    des_ip_ingreso = table.Column<string>(type: "text", nullable: false),
                    des_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    des_usuario_mod = table.Column<string>(type: "text", nullable: true),
                    des_ip_mod = table.Column<string>(type: "text", nullable: true),
                    des_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    des_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    des_ip_eliminacion = table.Column<string>(type: "text", nullable: true),
                    des_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DESTINO", x => x.des_id);
                });

            migrationBuilder.CreateTable(
                name: "IDIOMA",
                columns: table => new
                {
                    id_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_descripcion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    id_guid = table.Column<Guid>(type: "uuid", maxLength: 10, nullable: false),
                    id_estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDIOMA", x => x.id_id);
                });

            migrationBuilder.CreateTable(
                name: "INCLUYE",
                columns: table => new
                {
                    inc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inc_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    inc_descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    inc_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCLUYE", x => x.inc_id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rol_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    rol_descripcion = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    rol_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rol_usuario_ingreso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rol_ip_ingreso = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    rol_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rol_usuario_eliminacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rol_ip_eliminacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rol_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.rol_id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    usu_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usu_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    usu_login = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usu_password_hash = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    usu_fecha_registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usu_usuario_registro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usu_ip_registro = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    usu_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usu_usuario_mod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    usu_ip_mod = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    usu_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    usu_usuario_eliminacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    usu_ip_eliminacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    usu_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.usu_id);
                });

            migrationBuilder.CreateTable(
                name: "ATRACCION",
                columns: table => new
                {
                    at_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    des_id = table.Column<int>(type: "integer", nullable: false),
                    at_num_establecimiento = table.Column<string>(type: "text", nullable: true),
                    at_nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    at_descripcion = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    at_total_resenias = table.Column<int>(type: "integer", nullable: false),
                    at_direccion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    at_duracion_minutos = table.Column<int>(type: "integer", nullable: true),
                    at_punto_encuentro = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    at_precio_referencia = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    at_incluye_acompaniante = table.Column<bool>(type: "boolean", nullable: false),
                    at_incluye_transporte = table.Column<bool>(type: "boolean", nullable: false),
                    at_disponible = table.Column<bool>(type: "boolean", nullable: false),
                    at_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    at_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    at_ip_ingreso = table.Column<string>(type: "text", nullable: false),
                    at_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    at_usuario_mod = table.Column<string>(type: "text", nullable: true),
                    at_ip_mod = table.Column<string>(type: "text", nullable: true),
                    at_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    at_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    at_ip_eliminacion = table.Column<string>(type: "text", nullable: true),
                    at_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRACCION", x => x.at_id);
                    table.ForeignKey(
                        name: "FK_ATRACCION_DESTINO_des_id",
                        column: x => x.des_id,
                        principalTable: "DESTINO",
                        principalColumn: "des_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    cli_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    usu_id = table.Column<int>(type: "integer", nullable: false),
                    cli_tipo_identificacion = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    cli_numero_identificacion = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    cli_nombres = table.Column<string>(type: "text", nullable: true),
                    cli_apellidos = table.Column<string>(type: "text", nullable: true),
                    cli_correo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cli_telefono = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    cli_direccion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    cli_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cli_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    cli_ip_ingreso = table.Column<string>(type: "text", nullable: false),
                    cli_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cli_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    cli_ip_eliminacion = table.Column<string>(type: "text", nullable: true),
                    cli_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.cli_id);
                    table.ForeignKey(
                        name: "FK_CLIENTES_USUARIO_usu_id",
                        column: x => x.usu_id,
                        principalTable: "USUARIO",
                        principalColumn: "usu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOXROLES",
                columns: table => new
                {
                    usu_rol_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usu_id = table.Column<int>(type: "integer", nullable: false),
                    rol_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOXROLES", x => x.usu_rol_id);
                    table.ForeignKey(
                        name: "FK_USUARIOXROLES_ROLES_rol_id",
                        column: x => x.rol_id,
                        principalTable: "ROLES",
                        principalColumn: "rol_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USUARIOXROLES_USUARIO_usu_id",
                        column: x => x.usu_id,
                        principalTable: "USUARIO",
                        principalColumn: "usu_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ATRACCION_INCLUYE",
                columns: table => new
                {
                    inc_id = table.Column<int>(type: "integer", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    ai_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ai_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    ai_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ai_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    ai_estado = table.Column<string>(type: "text", nullable: false),
                    AtraccionAtId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATRACCION_INCLUYE", x => new { x.inc_id, x.at_id });
                    table.ForeignKey(
                        name: "FK_ATRACCION_INCLUYE_ATRACCION_AtraccionAtId",
                        column: x => x.AtraccionAtId,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id");
                    table.ForeignKey(
                        name: "FK_ATRACCION_INCLUYE_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ATRACCION_INCLUYE_INCLUYE_inc_id",
                        column: x => x.inc_id,
                        principalTable: "INCLUYE",
                        principalColumn: "inc_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA_ATRACCION",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "integer", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    ca_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ca_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    ca_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ca_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    ca_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA_ATRACCION", x => new { x.cat_id, x.at_id });
                    table.ForeignKey(
                        name: "FK_CATEGORIA_ATRACCION_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_ATRACCION_CATEGORIA_cat_id",
                        column: x => x.cat_id,
                        principalTable: "CATEGORIA",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IDIOMA_ATRACCION",
                columns: table => new
                {
                    IdId = table.Column<int>(type: "integer", nullable: false),
                    AtId = table.Column<int>(type: "integer", nullable: false),
                    AtraccionAtId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDIOMA_ATRACCION", x => new { x.IdId, x.AtId });
                    table.ForeignKey(
                        name: "FK_IDIOMA_ATRACCION_ATRACCION_AtId",
                        column: x => x.AtId,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IDIOMA_ATRACCION_ATRACCION_AtraccionAtId",
                        column: x => x.AtraccionAtId,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id");
                    table.ForeignKey(
                        name: "FK_IDIOMA_ATRACCION_IDIOMA_IdId",
                        column: x => x.IdId,
                        principalTable: "IDIOMA",
                        principalColumn: "id_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IMAGEN",
                columns: table => new
                {
                    img_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    img_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    img_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    img_descripcion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    img_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    img_usuario_ingreso = table.Column<string>(type: "text", nullable: false),
                    img_ip_ingreso = table.Column<string>(type: "text", nullable: false),
                    img_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_usuario_mod = table.Column<string>(type: "text", nullable: true),
                    img_ip_mod = table.Column<string>(type: "text", nullable: true),
                    img_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    img_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    img_ip_eliminacion = table.Column<string>(type: "text", nullable: true),
                    img_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMAGEN", x => x.img_id);
                    table.ForeignKey(
                        name: "FK_IMAGEN_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TICKET",
                columns: table => new
                {
                    tck_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tck_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    tck_titulo = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    tck_precio = table.Column<decimal>(type: "numeric", nullable: false),
                    tck_tipo_participante = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    tck_capacidad_maxima = table.Column<int>(type: "integer", nullable: false),
                    tck_cupos_disponibles = table.Column<int>(type: "integer", nullable: false),
                    tck_fecha_ingreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tck_usuario_ingreso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tck_ip_ingreso = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    tck_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tck_usuario_mod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tck_ip_mod = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tck_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    tck_usuario_eliminacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tck_ip_eliminacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    tck_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TICKET", x => x.tck_id);
                    table.ForeignKey(
                        name: "FK_TICKET_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESERVAS",
                columns: table => new
                {
                    rev_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rev_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    rev_codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    cli_id = table.Column<int>(type: "integer", nullable: false),
                    rev_fecha_reserva_utc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rev_subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    rev_valor_iva = table.Column<decimal>(type: "numeric", nullable: false),
                    rev_total = table.Column<decimal>(type: "numeric", nullable: false),
                    rev_origen_canal = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    rev_usuario_ingreso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rev_ip_ingreso = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    rev_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rev_usuario_mod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rev_ip_mod = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rev_fecha_cancelacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rev_usuario_cancelacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rev_ip_cancelacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rev_motivo_cancelacion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    rev_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    ClienteCliId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVAS", x => x.rev_id);
                    table.ForeignKey(
                        name: "FK_RESERVAS_CLIENTES_ClienteCliId",
                        column: x => x.ClienteCliId,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id");
                    table.ForeignKey(
                        name: "FK_RESERVAS_CLIENTES_cli_id",
                        column: x => x.cli_id,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FACTURAS",
                columns: table => new
                {
                    fac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fac_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    rev_id = table.Column<int>(type: "integer", nullable: false),
                    fac_numero = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fac_fecha_emision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fac_total = table.Column<decimal>(type: "numeric", nullable: false),
                    fac_observacion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    fac_origen_canal = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fac_estado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fac_usuario_ingreso = table.Column<string>(type: "text", nullable: true),
                    fac_ip_ingreso = table.Column<string>(type: "text", nullable: true),
                    fac_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fac_usuario_mod = table.Column<string>(type: "text", nullable: true),
                    fac_ip_mod = table.Column<string>(type: "text", nullable: true),
                    fac_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fac_usuario_eliminacion = table.Column<string>(type: "text", nullable: true),
                    fac_ip_eliminacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURAS", x => x.fac_id);
                    table.ForeignKey(
                        name: "FK_FACTURAS_RESERVAS_rev_id",
                        column: x => x.rev_id,
                        principalTable: "RESERVAS",
                        principalColumn: "rev_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESENIA",
                columns: table => new
                {
                    rsn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rsn_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    at_id = table.Column<int>(type: "integer", nullable: false),
                    cli_id = table.Column<int>(type: "integer", nullable: false),
                    rev_id = table.Column<int>(type: "integer", nullable: true),
                    rsn_rating = table.Column<int>(type: "integer", nullable: false),
                    rsn_comentario = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    rsn_fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rsn_usuario_creacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    rsn_ip_creacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    rsn_fecha_mod = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rsn_usuario_mod = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rsn_ip_mod = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rsn_fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    rsn_usuario_eliminacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    rsn_ip_eliminacion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: true),
                    rsn_estado = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    ClienteCliId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESENIA", x => x.rsn_id);
                    table.ForeignKey(
                        name: "FK_RESENIA_ATRACCION_at_id",
                        column: x => x.at_id,
                        principalTable: "ATRACCION",
                        principalColumn: "at_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESENIA_CLIENTES_ClienteCliId",
                        column: x => x.ClienteCliId,
                        principalTable: "CLIENTES",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESENIA_RESERVAS_rev_id",
                        column: x => x.rev_id,
                        principalTable: "RESERVAS",
                        principalColumn: "rev_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESERVA_DETALLE",
                columns: table => new
                {
                    rdet_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rdet_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    rev_id = table.Column<int>(type: "integer", nullable: false),
                    tck_id = table.Column<int>(type: "integer", nullable: false),
                    rdet_titulo = table.Column<string>(type: "text", nullable: true),
                    rdet_cantidad = table.Column<int>(type: "integer", nullable: false),
                    rdet_precio_unit = table.Column<decimal>(type: "numeric", nullable: false),
                    rdet_subtotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVA_DETALLE", x => x.rdet_id);
                    table.ForeignKey(
                        name: "FK_RESERVA_DETALLE_RESERVAS_rev_id",
                        column: x => x.rev_id,
                        principalTable: "RESERVAS",
                        principalColumn: "rev_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESERVA_DETALLE_TICKET_tck_id",
                        column: x => x.tck_id,
                        principalTable: "TICKET",
                        principalColumn: "tck_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DATOS_FACTURACION",
                columns: table => new
                {
                    dfac_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dfac_guid = table.Column<Guid>(type: "uuid", nullable: false),
                    fac_id = table.Column<int>(type: "integer", nullable: false),
                    dfac_nombre = table.Column<string>(type: "text", nullable: false),
                    dfac_apellido = table.Column<string>(type: "text", nullable: false),
                    dfac_correo = table.Column<string>(type: "text", nullable: false),
                    dfac_telefono = table.Column<string>(type: "text", nullable: true),
                    DfFechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                name: "IX_ATRACCION_des_id",
                table: "ATRACCION",
                column: "des_id");

            migrationBuilder.CreateIndex(
                name: "IX_ATRACCION_INCLUYE_at_id",
                table: "ATRACCION_INCLUYE",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_ATRACCION_INCLUYE_AtraccionAtId",
                table: "ATRACCION_INCLUYE",
                column: "AtraccionAtId");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_cat_parent_id",
                table: "CATEGORIA",
                column: "cat_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_ATRACCION_at_id",
                table: "CATEGORIA_ATRACCION",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_usu_id",
                table: "CLIENTES",
                column: "usu_id");

            migrationBuilder.CreateIndex(
                name: "IX_DATOS_FACTURACION_fac_id",
                table: "DATOS_FACTURACION",
                column: "fac_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAS_rev_id",
                table: "FACTURAS",
                column: "rev_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IDIOMA_ATRACCION_AtId",
                table: "IDIOMA_ATRACCION",
                column: "AtId");

            migrationBuilder.CreateIndex(
                name: "IX_IDIOMA_ATRACCION_AtraccionAtId",
                table: "IDIOMA_ATRACCION",
                column: "AtraccionAtId");

            migrationBuilder.CreateIndex(
                name: "IX_IMAGEN_at_id",
                table: "IMAGEN",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESENIA_at_id",
                table: "RESENIA",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESENIA_ClienteCliId",
                table: "RESENIA",
                column: "ClienteCliId");

            migrationBuilder.CreateIndex(
                name: "IX_RESENIA_rev_id",
                table: "RESENIA",
                column: "rev_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_DETALLE_rev_id",
                table: "RESERVA_DETALLE",
                column: "rev_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_DETALLE_tck_id",
                table: "RESERVA_DETALLE",
                column: "tck_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVAS_cli_id",
                table: "RESERVAS",
                column: "cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVAS_ClienteCliId",
                table: "RESERVAS",
                column: "ClienteCliId");

            migrationBuilder.CreateIndex(
                name: "IX_TICKET_at_id",
                table: "TICKET",
                column: "at_id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOXROLES_rol_id",
                table: "USUARIOXROLES",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOXROLES_usu_id",
                table: "USUARIOXROLES",
                column: "usu_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATRACCION_INCLUYE");

            migrationBuilder.DropTable(
                name: "AUDITORIA_LOG");

            migrationBuilder.DropTable(
                name: "CATEGORIA_ATRACCION");

            migrationBuilder.DropTable(
                name: "DATOS_FACTURACION");

            migrationBuilder.DropTable(
                name: "IDIOMA_ATRACCION");

            migrationBuilder.DropTable(
                name: "IMAGEN");

            migrationBuilder.DropTable(
                name: "RESENIA");

            migrationBuilder.DropTable(
                name: "RESERVA_DETALLE");

            migrationBuilder.DropTable(
                name: "USUARIOXROLES");

            migrationBuilder.DropTable(
                name: "INCLUYE");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "FACTURAS");

            migrationBuilder.DropTable(
                name: "IDIOMA");

            migrationBuilder.DropTable(
                name: "TICKET");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "RESERVAS");

            migrationBuilder.DropTable(
                name: "ATRACCION");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "DESTINO");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}

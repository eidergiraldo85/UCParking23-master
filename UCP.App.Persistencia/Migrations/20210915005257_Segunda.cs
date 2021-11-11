using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Oficina",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Parqueaderoid",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "actividad",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "autorizaid",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cubiculo",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "departamento",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dependencia",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "facultad",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "programa",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Parqueaderos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroPuestos = table.Column<int>(type: "int", nullable: false),
                    horario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picoPlaca = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueaderos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoVehiculo = table.Column<int>(type: "int", nullable: false),
                    numeroParquadero = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Puestos_Parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Puestos_Vehiculo_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valorHora = table.Column<float>(type: "real", nullable: false),
                    vehiculoid = table.Column<int>(type: "int", nullable: true),
                    Parqueaderoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Parqueaderos_Parqueaderoid",
                        column: x => x.Parqueaderoid,
                        principalTable: "Parqueaderos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacciones_Vehiculo_vehiculoid",
                        column: x => x.vehiculoid,
                        principalTable: "Vehiculo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_autorizaid",
                table: "Personas",
                column: "autorizaid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Parqueaderoid",
                table: "Personas",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Parqueaderoid",
                table: "Puestos",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_vehiculoid",
                table: "Puestos",
                column: "vehiculoid");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_Parqueaderoid",
                table: "Transacciones",
                column: "Parqueaderoid");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_vehiculoid",
                table: "Transacciones",
                column: "vehiculoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Parqueaderos_Parqueaderoid",
                table: "Personas",
                column: "Parqueaderoid",
                principalTable: "Parqueaderos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_autorizaid",
                table: "Personas",
                column: "autorizaid",
                principalTable: "Personas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Parqueaderos_Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_autorizaid",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Parqueaderos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_autorizaid",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Oficina",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Parqueaderoid",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "actividad",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "autorizaid",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "cubiculo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "departamento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "dependencia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "facultad",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "programa",
                table: "Personas");
        }
    }
}

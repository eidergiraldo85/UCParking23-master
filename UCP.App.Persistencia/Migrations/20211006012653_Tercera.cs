using Microsoft.EntityFrameworkCore.Migrations;

namespace UCP.App.Persistencia.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_1id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_2id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Puestos_Vehiculo_vehiculoid",
                table: "Puestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Vehiculo_vehiculoid",
                table: "Transacciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo");

            migrationBuilder.RenameTable(
                name: "Vehiculo",
                newName: "Vehiculos");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_1id",
                table: "Personas",
                column: "vehiculo_1id",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_2id",
                table: "Personas",
                column: "vehiculo_2id",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Vehiculos_vehiculoid",
                table: "Puestos",
                column: "vehiculoid",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Vehiculos_vehiculoid",
                table: "Transacciones",
                column: "vehiculoid",
                principalTable: "Vehiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_1id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Vehiculos_vehiculo_2id",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Puestos_Vehiculos_vehiculoid",
                table: "Puestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Vehiculos_vehiculoid",
                table: "Transacciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehiculos",
                table: "Vehiculos");

            migrationBuilder.RenameTable(
                name: "Vehiculos",
                newName: "Vehiculo");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehiculo",
                table: "Vehiculo",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_1id",
                table: "Personas",
                column: "vehiculo_1id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Vehiculo_vehiculo_2id",
                table: "Personas",
                column: "vehiculo_2id",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Vehiculo_vehiculoid",
                table: "Puestos",
                column: "vehiculoid",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Vehiculo_vehiculoid",
                table: "Transacciones",
                column: "vehiculoid",
                principalTable: "Vehiculo",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

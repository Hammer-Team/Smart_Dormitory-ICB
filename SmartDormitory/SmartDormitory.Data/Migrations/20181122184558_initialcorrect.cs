using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDormitory.Data.Migrations
{
    public partial class initialcorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_SensorType_SensorTypeId",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_SensorTypeId",
                table: "Sensors");

            migrationBuilder.AlterColumn<int>(
                name: "SensorTypeId",
                table: "Sensors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SensorTypeId1",
                table: "Sensors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorTypeId1",
                table: "Sensors",
                column: "SensorTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_SensorType_SensorTypeId1",
                table: "Sensors",
                column: "SensorTypeId1",
                principalTable: "SensorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_SensorType_SensorTypeId1",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_SensorTypeId1",
                table: "Sensors");

            migrationBuilder.DropColumn(
                name: "SensorTypeId1",
                table: "Sensors");

            migrationBuilder.AlterColumn<string>(
                name: "SensorTypeId",
                table: "Sensors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_SensorTypeId",
                table: "Sensors",
                column: "SensorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensors_SensorType_SensorTypeId",
                table: "Sensors",
                column: "SensorTypeId",
                principalTable: "SensorType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

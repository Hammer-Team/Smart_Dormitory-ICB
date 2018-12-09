using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDormitory.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "ID",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "SensorTypes",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Sensors",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Sensors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SensorTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { "1", "TemperatureSensor1" });

            migrationBuilder.InsertData(
                table: "SensorTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { "2", "TemperatureSensor5" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "ID", "Alarm", "ApiId", "Description", "IsDeleted", "IsPublic", "Latitude", "Longitude", "MeasurmentType", "Name", "PoolInterval", "SensorTypeId", "TimeStamp", "URLSensorData", "UserId", "Value", "ValueRangeMax", "ValueRangeMin" },
                values: new object[] { 384, true, "f1796a28-642e-401f-8129-fd7465417061", "Pre-defined sensor for development testing", false, true, "42.671892", "23.373758", "�C", "First sensor", 40, "1", null, "http://telerikacademy.icb.bg/api/sensor/f1796a28-642e-401f-8129-fd7465417061", "d01398e6-5a53-4826-98d1-543051f1f650", 21.0m, 28.0, 18.0 });
        }
    }
}

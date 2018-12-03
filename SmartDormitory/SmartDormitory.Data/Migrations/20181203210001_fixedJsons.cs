using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDormitory.Data.Migrations
{
    public partial class fixedJsons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "959596e5-93e4-4272-8cfb-6e71a4254370", "20d35162-b35c-4b2e-80c1-81a15bc1b2f3", "Administrator", "ADMINISTRATOR" },
                    { "5197310d-5d42-4337-bb59-2fd06e6a8fcd", "a3bc9d45-276b-442f-bc6b-b1a5763df30d", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", 0, "9d737330-f5d9-410c-a9e1-f8aec11903f9", "shaban9726@gmail.com", false, false, null, "SHABAN9726@GMAIL.COM", "SHABAN9726@GMAIL.COM", "AQAAAAEAACcQAAAAEFlZ3okaz7hZUfZV1qgvOLac2WRWCxSNuhzwaB9Of93MvQncQQYZj2fb6bLSH4VFRw==", null, false, "FJBKMINGFQAZNGSMZAIYUUQEVK4T74RU", false, "shaban9726@gmail.com" },
                    { "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", 0, "715dad2a-9a3f-4a7d-bca1-e40799bb172c", "user_pesho@abv.bg", false, false, null, "USER_PESHO@ABV.BG", "USER_PESHO@ABV.BG", "AQAAAAEAACcQAAAAECewgbwibVC/7nEpYLbJB26wOJyT9i8Dfcx6WFFCTnGy5xqwptVYNBIZEWK37eaaMA==", null, false, "WNDRYHCTXU3MSZ7NYBDFJQDL5VU2LBXS", false, "user_pesho@abv.bg" },
                    { "d01398e6-5a53-4826-98d1-543051f1f650", 0, "a5d37987-755a-455c-99f5-491cba1653f3", "nikitoo@google.com", false, false, null, "NIKITOO@GOOGLE.COM", "NIKITOO@GOOGLE.COM", "AQAAAAEAACcQAAAAEEBCEzE8UM/ctn9iYHx0yXeqwIePVskLBU69PYeUnFP2/P618XhOG2H+ySKQrto0fw==", null, false, "6Z332ORFPW5MUHETB564A4IZTGKNCJ6U", false, "nikitoo@google.com" }
                });

            migrationBuilder.InsertData(
                table: "SensorType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { "1", "TemperatureSensor1" },
                    { "2", "TemperatureSensor5" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", "959596e5-93e4-4272-8cfb-6e71a4254370" },
                    { "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", "5197310d-5d42-4337-bb59-2fd06e6a8fcd" },
                    { "d01398e6-5a53-4826-98d1-543051f1f650", "959596e5-93e4-4272-8cfb-6e71a4254370" }
                });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "ID", "Alarm", "ApiId", "Description", "IsDeleted", "IsPublic", "Latitude", "Longitude", "MeasurmentType", "Name", "PoolInterval", "SensorTypeId", "URLSensorData", "UserId", "Value", "ValueRangeMax", "ValueRangeMin" },
                values: new object[] { 384, true, "f1796a28-642e-401f-8129-fd7465417061", "Pre-defined sensor for development testing", false, true, "42.671892", "23.373758", "�C", "First sensor", 40, "1", "http://telerikacademy.icb.bg/api/sensor/f1796a28-642e-401f-8129-fd7465417061", "d01398e6-5a53-4826-98d1-543051f1f650", 21.0, 28.0, 18.0 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensors_SensorType_SensorTypeId",
                table: "Sensors");

            migrationBuilder.DropIndex(
                name: "IX_Sensors_SensorTypeId",
                table: "Sensors");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", "5197310d-5d42-4337-bb59-2fd06e6a8fcd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", "959596e5-93e4-4272-8cfb-6e71a4254370" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d01398e6-5a53-4826-98d1-543051f1f650", "959596e5-93e4-4272-8cfb-6e71a4254370" });

            migrationBuilder.DeleteData(
                table: "SensorType",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "ID",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5197310d-5d42-4337-bb59-2fd06e6a8fcd", "a3bc9d45-276b-442f-bc6b-b1a5763df30d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "959596e5-93e4-4272-8cfb-6e71a4254370", "20d35162-b35c-4b2e-80c1-81a15bc1b2f3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "31d4807f-7f5f-4ffa-90c1-a131e2d3855e", "715dad2a-9a3f-4a7d-bca1-e40799bb172c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "45a3335a-44de-44f7-b77c-bfa7d3c10a7c", "9d737330-f5d9-410c-a9e1-f8aec11903f9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d01398e6-5a53-4826-98d1-543051f1f650", "a5d37987-755a-455c-99f5-491cba1653f3" });

            migrationBuilder.DeleteData(
                table: "SensorType",
                keyColumn: "Id",
                keyValue: "1");

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
    }
}

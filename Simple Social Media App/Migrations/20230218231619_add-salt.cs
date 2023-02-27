using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Simple_Social_Media_App.Migrations
{
    /// <inheritdoc />
    public partial class addsalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salt",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3669));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3639));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3644));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Salt" },
                values: new object[] { new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3356), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "Salt" },
                values: new object[] { new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3363), 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateOfBirth", "Salt" },
                values: new object[] { new DateTime(2023, 2, 18, 23, 16, 19, 647, DateTimeKind.Utc).AddTicks(3364), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateOfBirth",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3659));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateOfBirth",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3667));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateOfBirth",
                value: new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3669));
        }
    }
}

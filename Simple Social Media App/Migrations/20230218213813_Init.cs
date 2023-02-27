using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Simple_Social_Media_App.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile_Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Description", "Email", "Full_Name", "Password", "Profile_Picture" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3659), null, "user1@mail.com", "Per Hansen", "pa$$w0rd", null },
                    { 2, new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3667), null, "user2@mail.com", "Bo Warmming", "pa$$w0rd", null },
                    { 3, new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3669), null, "user3@mail.com", "Rasmus Paludan", "pa$$w0rd", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "Image", "UserId" },
                values: new object[,]
                {
                    { 1, "Per Hansen ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3963), null, 1 },
                    { 2, "Bo Warmming ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3967), null, 2 },
                    { 3, "Rasmus Paludan ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3968), null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Bo Warmming - Thumbs Up ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3992), 1, 2 },
                    { 2, "Rasmus Paludan - Thumbs Up ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3997), 2, 3 },
                    { 3, "Per Hansen - Thumbs Up ...", new DateTime(2023, 2, 18, 21, 38, 13, 687, DateTimeKind.Utc).AddTicks(3999), 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

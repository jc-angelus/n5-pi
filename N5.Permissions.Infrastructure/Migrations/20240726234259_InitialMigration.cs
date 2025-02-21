using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N5.Permissions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEmployee = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SurnameEmployee = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PermissionTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionType_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Permission for marriege" },
                    { 2, "Permission for healt" },
                    { 3, "Permission for course" }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "NameEmployee", "PermissionDate", "PermissionTypeId", "SurnameEmployee" },
                values: new object[] { 1, "Johans", new DateTime(2024, 7, 26, 19, 42, 59, 258, DateTimeKind.Local).AddTicks(7942), 1, "Cuellar Faraco" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeId",
                table: "Permission",
                column: "PermissionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionType");
        }
    }
}

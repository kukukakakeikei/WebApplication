using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class initalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Account = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountType = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nickname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Classes = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DataCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlayerId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Account", "AccountType", "DataCreated" },
                values: new object[,]
                {
                    { new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0"), "dc2021", "Free", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(2518) },
                    { new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5"), "mw2021", "Free", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(2504) }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Classes", "DataCreated", "Level", "Nickname", "PlayerId" },
                values: new object[,]
                {
                    { new Guid("1f3b1016-223a-4ccc-b188-f2b5548fc1ac"), "Druid", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4118), 80, "Spider Man", new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5") },
                    { new Guid("536fb9d8-ec40-4ec5-8e04-f70ebd1e8a1c"), "Warrior", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4114), 90, "Iron Man", new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5") },
                    { new Guid("c12dd6e5-a143-49a4-ba09-cc9adfcddde0"), "Death knight", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4121), 90, "BatMan", new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0") },
                    { new Guid("dcb79c18-08df-4695-9487-686b08e931a3"), "Paladin", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(4122), 99, "SuperMan", new Guid("8ef15996-cebe-4b3e-9594-7c541421c2b0") },
                    { new Guid("e12b7286-157e-4c94-87aa-fbbd7eaf2a70"), "Mage", new DateTime(2024, 2, 6, 15, 37, 18, 622, DateTimeKind.Local).AddTicks(3879), 99, "Code Man", new Guid("dbff15ed-a31a-46f8-b82c-f49bef224ed5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_Nickname",
                table: "Characters",
                column: "Nickname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Account",
                table: "Players",
                column: "Account",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}

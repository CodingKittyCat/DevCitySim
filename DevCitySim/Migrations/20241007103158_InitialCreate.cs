using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevCitySim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Job = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CitizenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Citizens",
                columns: new[] { "Id", "DateOfBirth", "Job", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Elizabeth Grimthane" },
                    { 2, new DateTime(2003, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Cutie", "B'lu Poison" },
                    { 3, new DateTime(2001, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Hottie", "Kuree Maverick" },
                    { 4, new DateTime(1991, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Professional Cuddler", "Charlotte Farstrider" },
                    { 5, new DateTime(1995, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Amelia Dream" },
                    { 6, new DateTime(1981, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "Ava Star" },
                    { 7, new DateTime(1994, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer", "Sophia Blaze" },
                    { 8, new DateTime(2008, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher", "Mia Hawk" },
                    { 9, new DateTime(1990, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Noah Peace" },
                    { 10, new DateTime(1998, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurse", "Olivia Rivers" },
                    { 11, new DateTime(1988, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Emma Hope" },
                    { 12, new DateTime(2001, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientist", "Lucas Maverick" },
                    { 13, new DateTime(1994, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teacher", "Ethan Silver" },
                    { 14, new DateTime(1999, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineer", "Liam Strong" },
                    { 15, new DateTime(1987, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chef", "Sophia Blaze" },
                    { 16, new DateTime(1985, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scientist", "Isabella Light" },
                    { 17, new DateTime(1993, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nurse", "Jacob Fox" },
                    { 18, new DateTime(1989, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artist", "Daniel Iron" },
                    { 19, new DateTime(2000, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doctor", "Elizabeth Bright" },
                    { 20, new DateTime(1983, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Developer", "John Light" }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "CitizenId", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Nullstreet 13", "DevCityTech", "Office" },
                    { 2, 1, "Blustreet 1304", "Stargazer Offices", "Office" },
                    { 3, 1, "Destinystreet", "Memory Islands", "Cafe" },
                    { 4, 2, "Blustreet 1306", "July Care", "Daycare" },
                    { 5, 2, "Airlines 1214", "August Goodbyeport", "Airport" },
                    { 6, 2, "Airplanestreet 1710", "October Festivities", "House Party" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CitizenId",
                table: "Buildings",
                column: "CitizenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Citizens");
        }
    }
}

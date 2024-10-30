using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevCitySim.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Citizens_CitizenId",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CitizenId",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Buildings");

            migrationBuilder.CreateTable(
                name: "CitizenBuildings",
                columns: table => new
                {
                    CitizenId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenBuildings", x => new { x.CitizenId, x.BuildingId });
                    table.ForeignKey(
                        name: "FK_CitizenBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenBuildings_Citizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CitizenBuildings",
                columns: new[] { "BuildingId", "CitizenId", "Id" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 2, 2, 1 },
                    { 2, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenBuildings_BuildingId",
                table: "CitizenBuildings",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenBuildings");

            migrationBuilder.AddColumn<int>(
                name: "CitizenId",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CitizenId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 2,
                column: "CitizenId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 3,
                column: "CitizenId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 4,
                column: "CitizenId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 5,
                column: "CitizenId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: 6,
                column: "CitizenId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CitizenId",
                table: "Buildings",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Citizens_CitizenId",
                table: "Buildings",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

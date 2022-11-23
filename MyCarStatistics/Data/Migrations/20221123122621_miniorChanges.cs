using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarStatistics.Data.Migrations
{
    public partial class miniorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.RenameColumn(
                name: "DrivenKm",
                table: "Refuels",
                newName: "Trip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trip",
                table: "Refuels",
                newName: "DrivenKm");

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName" },
                values: new object[] { 1, "Peugeot" });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "BrandId", "ModelName" },
                values: new object[] { 1, 1, "206" });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandId",
                table: "CarModels",
                column: "BrandId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarStatistics.Data.Migrations
{
    public partial class ServiceDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangedParts",
                table: "Services",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "ChangedParts");
        }
    }
}

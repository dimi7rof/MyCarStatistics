using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCarStatistics.Data.Migrations
{
    public partial class ExpenseTripChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentKm",
                table: "Expenses",
                newName: "Trip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trip",
                table: "Expenses",
                newName: "CurrentKm");
        }
    }
}

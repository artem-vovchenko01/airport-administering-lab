using Microsoft.EntityFrameworkCore.Migrations;

namespace EFClasses.Migrations
{
    public partial class AddDelayReason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DelayReason",
                table: "Flights",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayReason",
                table: "Flights");
        }
    }
}

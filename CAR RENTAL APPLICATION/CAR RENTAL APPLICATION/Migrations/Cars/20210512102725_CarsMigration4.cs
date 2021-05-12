using Microsoft.EntityFrameworkCore.Migrations;

namespace CAR_RENTAL_APPLICATION.Migrations.Cars
{
    public partial class CarsMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImage",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarImagePath",
                table: "Cars",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarImagePath",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CarImage",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

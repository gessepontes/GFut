using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class Horary_Hour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HoraryExtra",
                newName: "Hour");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Horary",
                newName: "Hour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "HoraryExtra",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Horary",
                newName: "Description");
        }
    }
}

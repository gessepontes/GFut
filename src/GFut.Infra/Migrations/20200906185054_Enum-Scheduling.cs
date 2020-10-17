using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class EnumScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Scheduling",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Scheduling",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

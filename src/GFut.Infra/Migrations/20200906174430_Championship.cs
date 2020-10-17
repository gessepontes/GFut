using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class Championship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PlayerRegistration",
                table: "Championship",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_HoraryId",
                table: "Scheduling",
                column: "HoraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling",
                column: "HoraryId",
                principalTable: "Horary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_HoraryId",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "PlayerRegistration",
                table: "Championship");
        }
    }
}

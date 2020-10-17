using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class GroupChampionshipalter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupChampionships_Championship_ChampionshipId",
                table: "GroupChampionships");

            migrationBuilder.DropIndex(
                name: "IX_GroupChampionships_ChampionshipId",
                table: "GroupChampionships");

            migrationBuilder.DropColumn(
                name: "ChampionshipId",
                table: "GroupChampionships");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChampionshipId",
                table: "GroupChampionships",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupChampionships_ChampionshipId",
                table: "GroupChampionships",
                column: "ChampionshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupChampionships_Championship_ChampionshipId",
                table: "GroupChampionships",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class GFutDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayerChampionship_PlayerRegistration_MatchChampionshipId",
                table: "MatchPlayerChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayerChampionship_PlayerRegistrationId",
                table: "MatchPlayerChampionship",
                column: "PlayerRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayerChampionship_PlayerRegistration_PlayerRegistrationId",
                table: "MatchPlayerChampionship",
                column: "PlayerRegistrationId",
                principalTable: "PlayerRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayerChampionship_PlayerRegistration_PlayerRegistrationId",
                table: "MatchPlayerChampionship");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayerChampionship_PlayerRegistrationId",
                table: "MatchPlayerChampionship");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayerChampionship_PlayerRegistration_MatchChampionshipId",
                table: "MatchPlayerChampionship",
                column: "MatchChampionshipId",
                principalTable: "PlayerRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

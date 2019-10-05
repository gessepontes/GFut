using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class GFutDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_PersonId",
                table: "Scheduling",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_PersonId",
                table: "Championship",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Championship_Person_PersonId",
                table: "Championship",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Person_PersonId",
                table: "Scheduling",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Championship_Person_PersonId",
                table: "Championship");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Person_PersonId",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_PersonId",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Championship_PersonId",
                table: "Championship");
        }
    }
}

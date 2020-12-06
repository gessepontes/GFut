using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class ChangeScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling");

            migrationBuilder.AlterColumn<int>(
                name: "HoraryId",
                table: "Scheduling",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HoraryExtraId",
                table: "Scheduling",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_HoraryExtraId",
                table: "Scheduling",
                column: "HoraryExtraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling",
                column: "HoraryId",
                principalTable: "Horary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_HoraryExtra_HoraryExtraId",
                table: "Scheduling",
                column: "HoraryExtraId",
                principalTable: "HoraryExtra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_HoraryExtra_HoraryExtraId",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_HoraryExtraId",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "HoraryExtraId",
                table: "Scheduling");

            migrationBuilder.AlterColumn<int>(
                name: "HoraryId",
                table: "Scheduling",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Horary_HoraryId",
                table: "Scheduling",
                column: "HoraryId",
                principalTable: "Horary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

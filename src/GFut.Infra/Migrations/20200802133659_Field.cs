using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Field_Match_MatchId",
                table: "Field");

            migrationBuilder.DropIndex(
                name: "IX_Field_MatchId",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Field");

            migrationBuilder.RenameColumn(
                name: "Fone",
                table: "Player",
                newName: "Phone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Field",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Player",
                newName: "Fone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Field",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Field",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Field_MatchId",
                table: "Field",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Match_MatchId",
                table: "Field",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

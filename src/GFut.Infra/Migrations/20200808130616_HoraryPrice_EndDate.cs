using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class HoraryPrice_EndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoraryPrice_FieldItem_FieldItemId",
                table: "HoraryPrice");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "HoraryPrice",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_HoraryPrice_FieldItem_FieldItemId",
                table: "HoraryPrice",
                column: "FieldItemId",
                principalTable: "FieldItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoraryPrice_FieldItem_FieldItemId",
                table: "HoraryPrice");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "HoraryPrice",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoraryPrice_FieldItem_FieldItemId",
                table: "HoraryPrice",
                column: "FieldItemId",
                principalTable: "FieldItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

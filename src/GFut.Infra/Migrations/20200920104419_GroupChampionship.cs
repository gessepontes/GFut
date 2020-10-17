using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class GroupChampionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupChampionships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    ChampionshipId = table.Column<int>(nullable: false),
                    SubscriptionId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChampionships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupChampionships_Championship_ChampionshipId",
                        column: x => x.ChampionshipId,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupChampionships_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupChampionships_ChampionshipId",
                table: "GroupChampionships",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupChampionships_SubscriptionId",
                table: "GroupChampionships",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupChampionships");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Picture = table.Column<string>(type: "varchar(500)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Confirmation = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(200)", nullable: true),
                    IdPush = table.Column<string>(type: "varchar(200)", nullable: true),
                    Token = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    ProfileType = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProfile_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    HoraryId = table.Column<int>(type: "int", nullable: false),
                    SchedulingType = table.Column<int>(type: "int", nullable: false),
                    HoraryType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "char(1)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CustomerNotRegistered = table.Column<string>(type: "varchar(100)", nullable: false),
                    Fone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CancelDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersonCancelId = table.Column<int>(type: "int", nullable: true),
                    MarkedApp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scheduling_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Symbol = table.Column<string>(type: "varchar(500)", nullable: false),
                    Picture = table.Column<string>(type: "varchar(500)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "varchar(500)", nullable: true),
                    FundationDate = table.Column<DateTime>(type: "date", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Picture = table.Column<string>(type: "varchar(500)", nullable: false),
                    Fone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Dispensed = table.Column<bool>(type: "bit", nullable: false),
                    DispenseDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    ChampionshipId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "char(1)", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "char(1)", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerRegistration_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerRegistration_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ChampionshipType = table.Column<int>(type: "int", nullable: false),
                    RefereeType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    AmountTeam = table.Column<int>(type: "int", nullable: false),
                    ReleaseSubscription = table.Column<bool>(type: "bit", nullable: false),
                    GoBack = table.Column<bool>(type: "bit", nullable: false),
                    Picture = table.Column<string>(type: "varchar(500)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championship_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    FieldItemId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DayWeek = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horary_FieldItem_FieldItemId",
                        column: x => x.FieldItemId,
                        principalTable: "FieldItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoraryExtra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    FieldItemId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraryExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraryExtra_FieldItem_FieldItemId",
                        column: x => x.FieldItemId,
                        principalTable: "FieldItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchChampionship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    HomeSubscriptionId = table.Column<int>(type: "int", nullable: false),
                    GuestSubscriptionId = table.Column<int>(type: "int", nullable: false),
                    FieldItemId = table.Column<int>(type: "int", nullable: false),
                    HomePoints = table.Column<int>(type: "int", nullable: false),
                    GuestPoints = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<string>(type: "varchar(10)", nullable: false),
                    Observation = table.Column<string>(type: "varchar(300)", nullable: false),
                    Calculate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchChampionship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchChampionship_FieldItem_FieldItemId",
                        column: x => x.FieldItemId,
                        principalTable: "FieldItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchChampionship_Subscription_GuestSubscriptionId",
                        column: x => x.GuestSubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchChampionship_Subscription_HomeSubscriptionId",
                        column: x => x.HomeSubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayerChampionship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    MatchChampionshipId = table.Column<int>(type: "int", nullable: false),
                    PlayerRegistrationId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Card = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayerChampionship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayerChampionship_MatchChampionship_MatchChampionshipId",
                        column: x => x.MatchChampionshipId,
                        principalTable: "MatchChampionship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchPlayerChampionship_PlayerRegistration_PlayerRegistrationId",
                        column: x => x.PlayerRegistrationId,
                        principalTable: "PlayerRegistration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    GuestTeamId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    HomePoints = table.Column<int>(type: "int", nullable: false),
                    GuestPoints = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<string>(type: "varchar(10)", nullable: false),
                    TeamNotRegistered = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Team_GuestTeamId",
                        column: x => x.GuestTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Fone = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    MonthlyValue = table.Column<decimal>(nullable: false),
                    Scheduled = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Field_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "date", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Assistance = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayer_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_FieldId",
                table: "Championship",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Championship_PersonId",
                table: "Championship",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_MatchId",
                table: "Field",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_PersonId",
                table: "Field",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldItem_FieldId",
                table: "FieldItem",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Horary_FieldItemId",
                table: "Horary",
                column: "FieldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HoraryExtra_FieldItemId",
                table: "HoraryExtra",
                column: "FieldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FieldId",
                table: "Match",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_GuestTeamId",
                table: "Match",
                column: "GuestTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeTeamId",
                table: "Match",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchChampionship_FieldItemId",
                table: "MatchChampionship",
                column: "FieldItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchChampionship_GuestSubscriptionId",
                table: "MatchChampionship",
                column: "GuestSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchChampionship_HomeSubscriptionId",
                table: "MatchChampionship",
                column: "HomeSubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayer_MatchId",
                table: "MatchPlayer",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayerChampionship_MatchChampionshipId",
                table: "MatchPlayerChampionship",
                column: "MatchChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayerChampionship_PlayerRegistrationId",
                table: "MatchPlayerChampionship",
                column: "PlayerRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfile_PersonId",
                table: "PersonProfile",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRegistration_PlayerId",
                table: "PlayerRegistration",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerRegistration_SubscriptionId",
                table: "PlayerRegistration",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_PersonId",
                table: "Scheduling",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ChampionshipId",
                table: "Subscription",
                column: "ChampionshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_TeamId",
                table: "Subscription",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_PersonId",
                table: "Team",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Championship_ChampionshipId",
                table: "Subscription",
                column: "ChampionshipId",
                principalTable: "Championship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Championship_Field_FieldId",
                table: "Championship",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldItem_Field_FieldId",
                table: "FieldItem",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Field_FieldId",
                table: "Match",
                column: "FieldId",
                principalTable: "Field",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Field_FieldId",
                table: "Match");

            migrationBuilder.DropTable(
                name: "Horary");

            migrationBuilder.DropTable(
                name: "HoraryExtra");

            migrationBuilder.DropTable(
                name: "MatchPlayer");

            migrationBuilder.DropTable(
                name: "MatchPlayerChampionship");

            migrationBuilder.DropTable(
                name: "PersonProfile");

            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropTable(
                name: "MatchChampionship");

            migrationBuilder.DropTable(
                name: "PlayerRegistration");

            migrationBuilder.DropTable(
                name: "FieldItem");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}

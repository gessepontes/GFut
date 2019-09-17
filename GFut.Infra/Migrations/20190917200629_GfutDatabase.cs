using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GFut.Infra.Data.Migrations
{
    public partial class GfutDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HORARIOAGENDADO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IDHORARIO = table.Column<int>(nullable: false),
                    SchedulingType = table.Column<int>(nullable: false),
                    HoraryType = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    IdPerson = table.Column<int>(nullable: true),
                    CustomerNotRegistered = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true),
                    CancelDate = table.Column<DateTime>(nullable: true),
                    IdPersonCancel = table.Column<int>(nullable: true),
                    MarkedApp = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HORARIOAGENDADO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    Rg = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Fone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Confirmation = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IdPush = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Field",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    MonthlyValue = table.Column<decimal>(nullable: false),
                    Scheduled = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    IdPerson = table.Column<int>(nullable: false),
                    IdCity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    IdPerson = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonProfile_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IdPerson = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    DATAFUNDACAO = table.Column<DateTime>(nullable: false),
                    State = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Person_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Championship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ChampionshipType = table.Column<int>(nullable: false),
                    RefereeType = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IdField = table.Column<int>(nullable: false),
                    AmountTeam = table.Column<int>(nullable: false),
                    ReleaseSubscription = table.Column<bool>(nullable: false),
                    GoBack = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    IdPerson = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Championship_Field_IdField",
                        column: x => x.IdField,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IdField = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldItem_Field_IdField",
                        column: x => x.IdField,
                        principalTable: "Field",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Dispensed = table.Column<bool>(nullable: false),
                    DispenseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registered",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    IdChampionship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registered_Championship_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registered_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IdFieldItem = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DayWeek = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horary_FieldItem_IdFieldItem",
                        column: x => x.IdFieldItem,
                        principalTable: "FieldItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoraryExtra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IdFieldItem = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoraryExtra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoraryExtra_FieldItem_IdFieldItem",
                        column: x => x.IdFieldItem,
                        principalTable: "FieldItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_IdField",
                table: "Championship",
                column: "IdField");

            migrationBuilder.CreateIndex(
                name: "IX_Field_IdPerson",
                table: "Field",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_FieldItem_IdField",
                table: "FieldItem",
                column: "IdField");

            migrationBuilder.CreateIndex(
                name: "IX_Horary_IdFieldItem",
                table: "Horary",
                column: "IdFieldItem");

            migrationBuilder.CreateIndex(
                name: "IX_HoraryExtra_IdFieldItem",
                table: "HoraryExtra",
                column: "IdFieldItem");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProfile_IdPerson",
                table: "PersonProfile",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Player_IdTeam",
                table: "Player",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Registered_IdChampionship",
                table: "Registered",
                column: "IdChampionship");

            migrationBuilder.CreateIndex(
                name: "IX_Registered_IdTeam",
                table: "Registered",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdPerson",
                table: "Team",
                column: "IdPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HORARIOAGENDADO");

            migrationBuilder.DropTable(
                name: "Horary");

            migrationBuilder.DropTable(
                name: "HoraryExtra");

            migrationBuilder.DropTable(
                name: "PersonProfile");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Registered");

            migrationBuilder.DropTable(
                name: "FieldItem");

            migrationBuilder.DropTable(
                name: "Championship");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Field");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}

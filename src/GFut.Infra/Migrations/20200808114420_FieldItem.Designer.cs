﻿// <auto-generated />
using System;
using GFut.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GFut.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200808114420_FieldItem")]
    partial class FieldItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GFut.Domain.Models.Championship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("AmountTeam")
                        .HasColumnName("AmountTeam")
                        .HasColumnType("int");

                    b.Property<int>("ChampionshipType")
                        .HasColumnName("ChampionshipType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnName("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("FieldId")
                        .HasColumnName("FieldId")
                        .HasColumnType("int");

                    b.Property<bool>("GoBack")
                        .HasColumnName("GoBack")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<int>("PersonId")
                        .HasColumnName("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnName("Picture")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("RefereeType")
                        .HasColumnName("RefereeType")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate");

                    b.Property<bool>("ReleaseSubscription")
                        .HasColumnName("ReleaseSubscription")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnName("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("PersonId");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("GFut.Domain.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("Address");

                    b.Property<int>("CityId")
                        .HasColumnName("CityId");

                    b.Property<decimal>("MonthlyValue")
                        .HasColumnName("MonthlyValue");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name");

                    b.Property<int>("PersonId")
                        .HasColumnName("PersonId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnName("Picture");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<bool>("Scheduled")
                        .HasColumnName("Scheduled");

                    b.Property<decimal>("Value")
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("GFut.Domain.Models.FieldItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<int>("FieldId")
                        .HasColumnName("FieldId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Picture");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("FieldItem");
                });

            modelBuilder.Entity("GFut.Domain.Models.Horary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("DayWeek")
                        .HasColumnName("DayWeek");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<int>("FieldItemId")
                        .HasColumnName("FieldItemId");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("Id");

                    b.HasIndex("FieldItemId");

                    b.ToTable("Horary");
                });

            modelBuilder.Entity("GFut.Domain.Models.HoraryExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description");

                    b.Property<int>("FieldItemId")
                        .HasColumnName("FieldItemId");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("Id");

                    b.HasIndex("FieldItemId");

                    b.ToTable("HoraryExtra");
                });

            modelBuilder.Entity("GFut.Domain.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<int>("FieldId")
                        .HasColumnName("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("GuestPoints")
                        .HasColumnName("GuestPoints")
                        .HasColumnType("int");

                    b.Property<int>("GuestTeamId")
                        .HasColumnName("GuestTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomePoints")
                        .HasColumnName("HomePoints")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamId")
                        .HasColumnName("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnName("MatchDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnName("StartTime")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TeamNotRegistered")
                        .HasColumnName("TeamNotRegistered")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("GuestTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchChampionship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Calculate")
                        .HasColumnName("Calculate")
                        .HasColumnType("bit");

                    b.Property<int>("FieldItemId")
                        .HasColumnName("FieldItemId")
                        .HasColumnType("int");

                    b.Property<int>("GuestPoints")
                        .HasColumnName("GuestPoints")
                        .HasColumnType("int");

                    b.Property<int>("GuestSubscriptionId")
                        .HasColumnName("GuestSubscriptionId")
                        .HasColumnType("int");

                    b.Property<int>("HomePoints")
                        .HasColumnName("HomePoints")
                        .HasColumnType("int");

                    b.Property<int>("HomeSubscriptionId")
                        .HasColumnName("HomeSubscriptionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnName("MatchDate")
                        .HasColumnType("date");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnName("Observation")
                        .HasColumnType("varchar(300)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnName("StartTime")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("FieldItemId");

                    b.HasIndex("GuestSubscriptionId");

                    b.HasIndex("HomeSubscriptionId");

                    b.ToTable("MatchChampionship");
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Assistance");

                    b.Property<int>("MatchId")
                        .HasColumnName("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("int");

                    b.Property<int>("Points");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchPlayer");
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchPlayerChampionship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Card")
                        .HasColumnName("Card")
                        .HasColumnType("int");

                    b.Property<int>("MatchChampionshipId")
                        .HasColumnName("MatchChampionshipId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnName("Number")
                        .HasColumnType("int");

                    b.Property<int>("PlayerRegistrationId")
                        .HasColumnName("PlayerRegistrationId")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnName("Points")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("MatchChampionshipId");

                    b.HasIndex("PlayerRegistrationId");

                    b.ToTable("MatchPlayerChampionship");
                });

            modelBuilder.Entity("GFut.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BirthDate")
                        .HasColumnType("date");

                    b.Property<bool>("Confirmation")
                        .HasColumnName("Confirmation")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasColumnName("Cpf")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("IdPush")
                        .HasColumnName("IdPush")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnName("Picture")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<string>("Rg");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("SecurityStamp")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Token")
                        .HasColumnName("Token")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("GFut.Domain.Models.PersonProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("PersonId")
                        .HasColumnName("PersonId");

                    b.Property<int>("ProfileType")
                        .HasColumnName("ProfileType");

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonProfile");
                });

            modelBuilder.Entity("GFut.Domain.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DispenseDate")
                        .HasColumnName("DispenseDate")
                        .HasColumnType("date");

                    b.Property<bool>("Dispensed")
                        .HasColumnName("Dispensed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Phone")
                        .HasColumnName("Phone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnName("Picture")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Position")
                        .HasColumnName("Position")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<int>("TeamId")
                        .HasColumnName("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("GFut.Domain.Models.PlayerRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnName("ApprovedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PlayerId")
                        .HasColumnName("PlayerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("datetime");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("State")
                        .HasColumnType("char(1)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnName("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("PlayerRegistration");
                });

            modelBuilder.Entity("GFut.Domain.Models.Scheduling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CancelDate")
                        .IsRequired()
                        .HasColumnName("CancelDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerNotRegistered")
                        .IsRequired()
                        .HasColumnName("CustomerNotRegistered")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("date");

                    b.Property<string>("Fone")
                        .IsRequired()
                        .HasColumnName("Fone")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("HoraryId")
                        .HasColumnName("HoraryId")
                        .HasColumnType("int");

                    b.Property<int>("HoraryType")
                        .HasColumnName("HoraryType")
                        .HasColumnType("int");

                    b.Property<bool>("MarkedApp")
                        .HasColumnName("MarkedApp")
                        .HasColumnType("bit");

                    b.Property<int?>("PersonCancelId")
                        .HasColumnName("PersonCancelId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnName("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<int>("SchedulingType")
                        .HasColumnName("SchedulingType")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnName("State")
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Scheduling");
                });

            modelBuilder.Entity("GFut.Domain.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ApprovedDate")
                        .HasColumnName("ApprovedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ChampionshipId")
                        .HasColumnName("ChampionshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnName("State")
                        .HasColumnType("char(1)");

                    b.Property<int>("TeamId")
                        .HasColumnName("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChampionshipId");

                    b.HasIndex("TeamId");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("GFut.Domain.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnName("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FundationDate")
                        .HasColumnName("FundationDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Observation")
                        .HasColumnName("Observation")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("PersonId")
                        .HasColumnName("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnName("Picture")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnName("RegisterDate")
                        .HasColumnType("date");

                    b.Property<bool>("State")
                        .HasColumnName("State")
                        .HasColumnType("bit");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnName("Symbol")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Type")
                        .HasColumnName("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("GFut.Domain.Models.Championship", b =>
                {
                    b.HasOne("GFut.Domain.Models.Field", "Field")
                        .WithMany("Championship")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Person", "Person")
                        .WithMany("Championship")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Field", b =>
                {
                    b.HasOne("GFut.Domain.Models.Person", "Person")
                        .WithMany("Field")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.FieldItem", b =>
                {
                    b.HasOne("GFut.Domain.Models.Field", "Field")
                        .WithMany("FieldItens")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Horary", b =>
                {
                    b.HasOne("GFut.Domain.Models.FieldItem", "FieldItem")
                        .WithMany("Horarys")
                        .HasForeignKey("FieldItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.HoraryExtra", b =>
                {
                    b.HasOne("GFut.Domain.Models.FieldItem", "FieldItem")
                        .WithMany("HoraryExtras")
                        .HasForeignKey("FieldItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Match", b =>
                {
                    b.HasOne("GFut.Domain.Models.Field", "Field")
                        .WithMany("Matches")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Team", "GuestTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("GuestTeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Team", "HomeTeam")
                        .WithMany("HomeMatches")
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchChampionship", b =>
                {
                    b.HasOne("GFut.Domain.Models.FieldItem", "FieldItem")
                        .WithMany("MatchChampionships")
                        .HasForeignKey("FieldItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Subscription", "GuestSubscription")
                        .WithMany("AwayChampionshipMatches")
                        .HasForeignKey("GuestSubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Subscription", "HomeSubscription")
                        .WithMany("HomeChampionshipMatches")
                        .HasForeignKey("HomeSubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchPlayer", b =>
                {
                    b.HasOne("GFut.Domain.Models.Match", "Match")
                        .WithMany("MatchPlayer")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.MatchPlayerChampionship", b =>
                {
                    b.HasOne("GFut.Domain.Models.MatchChampionship", "MatchChampionship")
                        .WithMany("MatchPlayerChampionships")
                        .HasForeignKey("MatchChampionshipId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.PlayerRegistration", "PlayerRegistration")
                        .WithMany("MatchPlayerChampionships")
                        .HasForeignKey("PlayerRegistrationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.PersonProfile", b =>
                {
                    b.HasOne("GFut.Domain.Models.Person", "Person")
                        .WithMany("PersonProfiles")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Player", b =>
                {
                    b.HasOne("GFut.Domain.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.PlayerRegistration", b =>
                {
                    b.HasOne("GFut.Domain.Models.Player", "Player")
                        .WithMany("PlayerRegistration")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Subscription", "Subscription")
                        .WithMany("PlayerRegistration")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Scheduling", b =>
                {
                    b.HasOne("GFut.Domain.Models.Person", "Person")
                        .WithMany("Scheduling")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Subscription", b =>
                {
                    b.HasOne("GFut.Domain.Models.Championship", "Championship")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GFut.Domain.Models.Team", "Team")
                        .WithMany("Subscriptions")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GFut.Domain.Models.Team", b =>
                {
                    b.HasOne("GFut.Domain.Models.Person", "Person")
                        .WithMany("Teams")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
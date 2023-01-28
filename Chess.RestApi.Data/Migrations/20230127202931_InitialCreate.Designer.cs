﻿// <auto-generated />
using System;
using Chess.RestApi.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chess.RestApi.Data.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230127202931_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Accounts")
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Capture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaptureSquareName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<Guid>("MoveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MoveId")
                        .IsUnique();

                    b.ToTable("Captures", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Castle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArrivalSquareName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("DepartureSquareName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<Guid>("MoveId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MoveId")
                        .IsUnique();

                    b.ToTable("Castles", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("GameSetupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameSetupId");

                    b.ToTable("Games", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.GameEnding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeCreate")
                        .HasColumnType("datetime");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StrongName")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("varchar");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.HasIndex("LoserId");

                    b.HasIndex("WinnerId");

                    b.ToTable("GameEndings", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.GameSetup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GameMode")
                        .HasColumnType("int");

                    b.Property<string>("InitialChessBoardState")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("TimeIncrement")
                        .HasColumnType("int");

                    b.Property<int?>("TimeLimit")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GameSetups", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.GameState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CapturedPieces")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("CastlingRights")
                        .HasMaxLength(4)
                        .HasColumnType("varchar");

                    b.Property<string>("ChessBoardState")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("EnPassantSquareName")
                        .HasMaxLength(2)
                        .HasColumnType("char");

                    b.Property<int>("FiftyMoveRuleClock")
                        .HasColumnType("int");

                    b.Property<Guid>("TurnId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TurnId")
                        .IsUnique();

                    b.ToTable("GameStates", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArrivalSquareName")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("char");

                    b.Property<string>("DepartureSquareName")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("char");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<Guid>("TurnId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurnId")
                        .IsUnique();

                    b.ToTable("Moves", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Players", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Promotion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MoveId")
                        .IsUnique();

                    b.ToTable("Promotions", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Queue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameSetupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameSetupId");

                    b.ToTable("Queues", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.QueueRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("JoinDateTime")
                        .HasColumnType("datetime");

                    b.Property<Guid>("QueueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QueueId");

                    b.HasIndex("UserId");

                    b.ToTable("QueueRequests", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "Accounts");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Turn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateTimeTo")
                        .HasColumnType("datetime");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TurnClock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Turns", "chess");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(19)
                        .HasColumnType("varchar");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasMaxLength(128)
                        .HasColumnType("varchar");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Users", "Accounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "Accounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "Accounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "Accounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "Accounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "Accounts");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Capture", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Move", "Move")
                        .WithOne("Capture")
                        .HasForeignKey("Chess.RestApi.Data.Entities.Capture", "MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Castle", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Move", "Move")
                        .WithOne("Castle")
                        .HasForeignKey("Chess.RestApi.Data.Entities.Castle", "MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Game", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.GameSetup", "GameSetup")
                        .WithMany()
                        .HasForeignKey("GameSetupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSetup");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.GameEnding", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Game", "Game")
                        .WithOne("GameEnding")
                        .HasForeignKey("Chess.RestApi.Data.Entities.GameEnding", "GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess.RestApi.Data.Entities.Player", "Loser")
                        .WithMany()
                        .HasForeignKey("LoserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Chess.RestApi.Data.Entities.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Game");

                    b.Navigation("Loser");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.GameState", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Turn", "Turn")
                        .WithOne("GameState")
                        .HasForeignKey("Chess.RestApi.Data.Entities.GameState", "TurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Move", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Turn", "Turn")
                        .WithOne("Move")
                        .HasForeignKey("Chess.RestApi.Data.Entities.Move", "TurnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turn");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Player", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess.RestApi.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Promotion", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Move", "Move")
                        .WithOne("Promotion")
                        .HasForeignKey("Chess.RestApi.Data.Entities.Promotion", "MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Queue", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.GameSetup", "GameSetup")
                        .WithMany()
                        .HasForeignKey("GameSetupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSetup");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.QueueRequest", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Queue", "Queue")
                        .WithMany("Requests")
                        .HasForeignKey("QueueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess.RestApi.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Queue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Turn", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Game", "Game")
                        .WithMany("Turns")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chess.RestApi.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Chess.RestApi.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Game", b =>
                {
                    b.Navigation("GameEnding")
                        .IsRequired();

                    b.Navigation("Players");

                    b.Navigation("Turns");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Move", b =>
                {
                    b.Navigation("Capture")
                        .IsRequired();

                    b.Navigation("Castle")
                        .IsRequired();

                    b.Navigation("Promotion")
                        .IsRequired();
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Queue", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Chess.RestApi.Data.Entities.Turn", b =>
                {
                    b.Navigation("GameState")
                        .IsRequired();

                    b.Navigation("Move")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

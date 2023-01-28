using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chess.RestApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accounts");

            migrationBuilder.EnsureSchema(
                name: "chess");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSetups",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InitialChessBoardState = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: true),
                    TimeIncrement = table.Column<int>(type: "int", nullable: false),
                    GameMode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSetups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    SecurityStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(19)", maxLength: 19, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Accounts",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    GameSetupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameSetups_GameSetupId",
                        column: x => x.GameSetupId,
                        principalSchema: "chess",
                        principalTable: "GameSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Queues",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameSetupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Queues_GameSetups_GameSetupId",
                        column: x => x.GameSetupId,
                        principalSchema: "chess",
                        principalTable: "GameSetups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Accounts",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Accounts",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Accounts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "chess",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turns",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurnClock = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    DateTimeFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateTimeTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turns_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "chess",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueRequests",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QueueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueRequests_Queues_QueueId",
                        column: x => x.QueueId,
                        principalSchema: "chess",
                        principalTable: "Queues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QueueRequests_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Accounts",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameEndings",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StrongName = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Details = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DateTimeCreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LoserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEndings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEndings_Games_GameId",
                        column: x => x.GameId,
                        principalSchema: "chess",
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEndings_Players_LoserId",
                        column: x => x.LoserId,
                        principalSchema: "chess",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameEndings_Players_WinnerId",
                        column: x => x.WinnerId,
                        principalSchema: "chess",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameStates",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChessBoardState = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CastlingRights = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: true),
                    EnPassantSquareName = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    FiftyMoveRuleClock = table.Column<int>(type: "int", nullable: false),
                    CapturedPieces = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameStates_Turns_TurnId",
                        column: x => x.TurnId,
                        principalSchema: "chess",
                        principalTable: "Turns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DepartureSquareName = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ArrivalSquareName = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TurnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Turns_TurnId",
                        column: x => x.TurnId,
                        principalSchema: "chess",
                        principalTable: "Turns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captures",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaptureSquareName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MoveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captures_Moves_MoveId",
                        column: x => x.MoveId,
                        principalSchema: "chess",
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Castles",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureSquareName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    ArrivalSquareName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    MoveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Castles_Moves_MoveId",
                        column: x => x.MoveId,
                        principalSchema: "chess",
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                schema: "chess",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    MoveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_Moves_MoveId",
                        column: x => x.MoveId,
                        principalSchema: "chess",
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Accounts",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Accounts",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Accounts",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Accounts",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Accounts",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Captures_MoveId",
                schema: "chess",
                table: "Captures",
                column: "MoveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Castles_MoveId",
                schema: "chess",
                table: "Castles",
                column: "MoveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEndings_GameId",
                schema: "chess",
                table: "GameEndings",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEndings_LoserId",
                schema: "chess",
                table: "GameEndings",
                column: "LoserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEndings_WinnerId",
                schema: "chess",
                table: "GameEndings",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameSetupId",
                schema: "chess",
                table: "Games",
                column: "GameSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_GameStates_TurnId",
                schema: "chess",
                table: "GameStates",
                column: "TurnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moves_TurnId",
                schema: "chess",
                table: "Moves",
                column: "TurnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                schema: "chess",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                schema: "chess",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_MoveId",
                schema: "chess",
                table: "Promotions",
                column: "MoveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QueueRequests_QueueId",
                schema: "chess",
                table: "QueueRequests",
                column: "QueueId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueRequests_UserId",
                schema: "chess",
                table: "QueueRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Queues_GameSetupId",
                schema: "chess",
                table: "Queues",
                column: "GameSetupId");

            migrationBuilder.CreateIndex(
                name: "IX_Turns_GameId",
                schema: "chess",
                table: "Turns",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Accounts",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Accounts",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Captures",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Castles",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "GameEndings",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "GameStates",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Promotions",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "QueueRequests",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Moves",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Queues",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Accounts");

            migrationBuilder.DropTable(
                name: "Turns",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "Games",
                schema: "chess");

            migrationBuilder.DropTable(
                name: "GameSetups",
                schema: "chess");
        }
    }
}

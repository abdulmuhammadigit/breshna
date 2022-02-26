using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pro.DataAccess.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaim_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaim_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JaktionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tazkira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBrashna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    OwnerSave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghozar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhozarLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWFAge = table.Column<int>(type: "int", nullable: false),
                    EType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseGenerator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourUG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenUG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseG = table.Column<double>(type: "float", nullable: false),
                    SourceE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceEType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    WC = table.Column<int>(type: "int", nullable: false),
                    Kichen = table.Column<int>(type: "int", nullable: false),
                    TypeHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaBuilding = table.Column<double>(type: "float", nullable: false),
                    Land = table.Column<double>(type: "float", nullable: false),
                    AirCandition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseTypeWarming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourOnStove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeYear = table.Column<int>(type: "int", nullable: false),
                    StaffCount = table.Column<int>(type: "int", nullable: false),
                    BillRecive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillDayDaily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhastVar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseOld = table.Column<double>(type: "float", nullable: false),
                    PayOnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAlltime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EHour = table.Column<int>(type: "int", nullable: false),
                    WantEAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayForEAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BSolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolorAmountAssets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WayContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rezayat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountLiveINFamily = table.Column<int>(type: "int", nullable: false),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OwnerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owners_Owners_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JaktionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tazkira = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBrashna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    RentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncomeMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Village = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghozar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhozarLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneLive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWFAge = table.Column<int>(type: "int", nullable: false),
                    EType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseGenerator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourUG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenUG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseG = table.Column<double>(type: "float", nullable: false),
                    SourceE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceEType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    WC = table.Column<int>(type: "int", nullable: false),
                    Kichen = table.Column<int>(type: "int", nullable: false),
                    TypeHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaBuilding = table.Column<double>(type: "float", nullable: false),
                    Land = table.Column<double>(type: "float", nullable: false),
                    AirCandition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseTypeWarming = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourOnStove = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeHome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeYear = table.Column<int>(type: "int", nullable: false),
                    StaffCount = table.Column<int>(type: "int", nullable: false),
                    BillRecive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillDayDaily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhastVar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseOld = table.Column<double>(type: "float", nullable: false),
                    PayOnTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAlltime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EHour = table.Column<int>(type: "int", nullable: false),
                    WantEAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayForEAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BSolor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolorAmountAssets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WayContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rezayat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountLiveINFamily = table.Column<int>(type: "int", nullable: false),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rents_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EEquipmentComs",
                columns: table => new
                {
                    EEquipmentComID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    AstahlakYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEquipmentComs", x => x.EEquipmentComID);
                    table.ForeignKey(
                        name: "FK_EEquipmentComs_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EEquipmentHs",
                columns: table => new
                {
                    EEquipmentHID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    AstahlakYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EEquipmentHs", x => x.EEquipmentHID);
                    table.ForeignKey(
                        name: "FK_EEquipmentHs_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerLanguages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_OwnerLanguages_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerTypeWarmings",
                columns: table => new
                {
                    TypeWarmingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerTypeWarmings", x => x.TypeWarmingId);
                    table.ForeignKey(
                        name: "FK_OwnerTypeWarmings_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PowerMeters",
                columns: table => new
                {
                    PowerMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMeter = table.Column<int>(type: "int", nullable: false),
                    DigitalOrAnalog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerMeters", x => x.PowerMeterId);
                    table.ForeignKey(
                        name: "FK_PowerMeters_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<double>(type: "float", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.ResidentId);
                    table.ForeignKey(
                        name: "FK_Residents_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentEEquipmentHs",
                columns: table => new
                {
                    EEquipmentHID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    AstahlakYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentEEquipmentHs", x => x.EEquipmentHID);
                    table.ForeignKey(
                        name: "FK_RentEEquipmentHs_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentEquipmentComs",
                columns: table => new
                {
                    EEquipmentComID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    AstahlakYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentEquipmentComs", x => x.EEquipmentComID);
                    table.ForeignKey(
                        name: "FK_RentEquipmentComs_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentLanguages", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_RentLanguages_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentPowerMeters",
                columns: table => new
                {
                    PowerMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMeter = table.Column<int>(type: "int", nullable: false),
                    DigitalOrAnalog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPowerMeters", x => x.PowerMeterId);
                    table.ForeignKey(
                        name: "FK_RentPowerMeters_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentResidents",
                columns: table => new
                {
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Income = table.Column<double>(type: "float", nullable: false),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentResidents", x => x.ResidentId);
                    table.ForeignKey(
                        name: "FK_RentResidents_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentTypeWarmings",
                columns: table => new
                {
                    TypeWarmingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTypeWarmings", x => x.TypeWarmingId);
                    table.ForeignKey(
                        name: "FK_RentTypeWarmings_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaim_RoleId",
                table: "AppRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaim_UserId",
                table: "AppUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EEquipmentComs_OwnerId",
                table: "EEquipmentComs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_EEquipmentHs_OwnerId",
                table: "EEquipmentHs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLanguages_OwnerId",
                table: "OwnerLanguages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnerId1",
                table: "Owners",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerTypeWarmings_OwnerId",
                table: "OwnerTypeWarmings",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerMeters_OwnerId",
                table: "PowerMeters",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentEEquipmentHs_RentId",
                table: "RentEEquipmentHs",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentEquipmentComs_RentId",
                table: "RentEquipmentComs",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentLanguages_RentId",
                table: "RentLanguages",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentPowerMeters_RentId",
                table: "RentPowerMeters",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_RentResidents_RentId",
                table: "RentResidents",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentTypeWarmings_RentId",
                table: "RentTypeWarmings",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_Residents_OwnerId",
                table: "Residents",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaim");

            migrationBuilder.DropTable(
                name: "AppUserClaim");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EEquipmentComs");

            migrationBuilder.DropTable(
                name: "EEquipmentHs");

            migrationBuilder.DropTable(
                name: "OwnerLanguages");

            migrationBuilder.DropTable(
                name: "OwnerTypeWarmings");

            migrationBuilder.DropTable(
                name: "PowerMeters");

            migrationBuilder.DropTable(
                name: "RentEEquipmentHs");

            migrationBuilder.DropTable(
                name: "RentEquipmentComs");

            migrationBuilder.DropTable(
                name: "RentLanguages");

            migrationBuilder.DropTable(
                name: "RentPowerMeters");

            migrationBuilder.DropTable(
                name: "RentResidents");

            migrationBuilder.DropTable(
                name: "RentTypeWarmings");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}

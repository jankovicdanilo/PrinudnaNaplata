using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrinudnaNaplata.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCharts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CostCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCharts", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProofLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VatNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VatRate = table.Column<decimal>(type: "decimal(15,3)", nullable: true),
                    AddVatToAttorneyFee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Courts",
                columns: table => new
                {
                    CourtId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ShortFullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courts", x => x.CourtId);
                });

            migrationBuilder.CreateTable(
                name: "Debtors",
                columns: table => new
                {
                    DebtorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditorReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    City = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    PersonalId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    IsUnknown = table.Column<bool>(type: "bit", nullable: false),
                    IsDeceased = table.Column<bool>(type: "bit", nullable: false),
                    IsPensioner = table.Column<bool>(type: "bit", nullable: false),
                    District = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RealEstate = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    IsLegalEntity = table.Column<bool>(type: "bit", nullable: true),
                    IsMarked = table.Column<bool>(type: "bit", nullable: false),
                    Vehicles = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    BankAccountNumbers = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debtors", x => x.DebtorId);
                });

            migrationBuilder.CreateTable(
                name: "DefaultAttorneyTariffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TariffAmount = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    TariffPercentage = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultAttorneyTariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnforcementCases",
                columns: table => new
                {
                    CaseId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebtorId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CourtId = table.Column<long>(type: "bigint", nullable: true),
                    SecondaryCourtId = table.Column<long>(type: "bigint", nullable: true),
                    CaseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DecisionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EnforcementNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CourtOrderNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MinorOffenseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ExecutionNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RequestNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    JoinedUnderNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DebtFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DebtTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DebtAmount = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    AttorneyFee = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CourtFees = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CurrentDebt = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PaidAmount = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    DebtAmountAfterObjection = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    AttorneyFeeAfterObjection = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    CourtFeesAfterObjection = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    AdditionalAttorneyFee = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    SuccessPercentage = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    BillingPercentage = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnforcedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostponedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnforcementDecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrialDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstInstanceJudgmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondInstanceJudgmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MortgageDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovablePropertyProposalSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovablePropertyProposalIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImmovablePropertyProposalSubmitted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImmovablePropertyProposalIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsBilled = table.Column<bool>(type: "bit", nullable: false),
                    IsDeliveryConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsSentToTreasury = table.Column<bool>(type: "bit", nullable: false),
                    IsPrincipalDebtPaid = table.Column<bool>(type: "bit", nullable: false),
                    HasObjection = table.Column<bool>(type: "bit", nullable: false),
                    IsObjectionUpheld = table.Column<bool>(type: "bit", nullable: false),
                    IsObjectionDismissed = table.Column<bool>(type: "bit", nullable: false),
                    IsObjectionRejected = table.Column<bool>(type: "bit", nullable: false),
                    IsInventoried = table.Column<bool>(type: "bit", nullable: false),
                    IsAppraised = table.Column<bool>(type: "bit", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    IsPostponed = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    IsTerminated = table.Column<bool>(type: "bit", nullable: false),
                    IsRefused = table.Column<bool>(type: "bit", nullable: false),
                    HasEnforcementDecision = table.Column<bool>(type: "bit", nullable: false),
                    HasSettlement = table.Column<bool>(type: "bit", nullable: false),
                    HasFirstInstanceJudgment = table.Column<bool>(type: "bit", nullable: false),
                    HasAppeal = table.Column<bool>(type: "bit", nullable: false),
                    HasSecondInstanceJudgment = table.Column<bool>(type: "bit", nullable: false),
                    HasJudgmentEnforcement = table.Column<bool>(type: "bit", nullable: false),
                    IsDeceased = table.Column<bool>(type: "bit", nullable: false),
                    HasNoMovableProperty = table.Column<bool>(type: "bit", nullable: false),
                    HasOrderAndInstruction = table.Column<bool>(type: "bit", nullable: false),
                    HasOrderNotCompliedWith = table.Column<bool>(type: "bit", nullable: false),
                    HasMovablePropertyProposal = table.Column<bool>(type: "bit", nullable: false),
                    HasImmovablePropertyProposal = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalBilling = table.Column<bool>(type: "bit", nullable: false),
                    HasPublicAnnouncement = table.Column<bool>(type: "bit", nullable: false),
                    HasMortgage = table.Column<bool>(type: "bit", nullable: false),
                    BillAttorneyFee = table.Column<bool>(type: "bit", nullable: false),
                    BillWithVat = table.Column<bool>(type: "bit", nullable: false),
                    DoNotBill = table.Column<bool>(type: "bit", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnforcementCases", x => x.CaseId);
                });

            migrationBuilder.CreateTable(
                name: "UserClientAccesses",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CanEdit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClientAccesses", x => new { x.UserName, x.ClientId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCharts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Courts");

            migrationBuilder.DropTable(
                name: "Debtors");

            migrationBuilder.DropTable(
                name: "DefaultAttorneyTariffs");

            migrationBuilder.DropTable(
                name: "EnforcementCases");

            migrationBuilder.DropTable(
                name: "UserClientAccesses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

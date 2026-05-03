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
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    table.UniqueConstraint("AK_AspNetUsers_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Klijenti",
                columns: table => new
                {
                    KlijentID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Valuta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Zemlja = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Racun = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dokaz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PozvatiSeNa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIB = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PDV = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PDVStopa = table.Column<decimal>(type: "decimal(15,3)", nullable: true),
                    DodajPDVNaAdvTarifu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijenti", x => x.KlijentID);
                });

            migrationBuilder.CreateTable(
                name: "KontniPlan",
                columns: table => new
                {
                    KontoBroj = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KontniPlan", x => x.KontoBroj);
                });

            migrationBuilder.CreateTable(
                name: "Preduzeca",
                columns: table => new
                {
                    PreduzeceID = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mjesto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefoni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZiroRacun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontaktOsoba = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIB = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preduzeca", x => x.PreduzeceID);
                });

            migrationBuilder.CreateTable(
                name: "Sudovi",
                columns: table => new
                {
                    SudID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Mjesto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KratakNaziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KratakPuniNaziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sudovi", x => x.SudID);
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

            migrationBuilder.CreateTable(
                name: "PodrazumijevaneAdvokatskeTarife",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarifa = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    TarifaProcenat = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    KlijentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodrazumijevaneAdvokatskeTarife", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PodrazumijevaneAdvokatskeTarife_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PravaPristupaKlijent",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    KlijentID = table.Column<int>(type: "int", nullable: false),
                    Izmjena = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PravaPristupaKlijent", x => new { x.UserName, x.KlijentID });
                    table.ForeignKey(
                        name: "FK_PravaPristupaKlijent_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PravaPristupaKlijent_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duznici",
                columns: table => new
                {
                    DuznikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZavedenKodPov = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    Mjesto = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    JMBG = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RegBr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LicniBroj = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PreduzeceID = table.Column<int>(type: "int", nullable: true),
                    Nepoznat = table.Column<bool>(type: "bit", nullable: false),
                    Umro = table.Column<bool>(type: "bit", nullable: false),
                    Penzioner = table.Column<bool>(type: "bit", nullable: false),
                    Reon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Nekretnina = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    PravnoLice = table.Column<bool>(type: "bit", nullable: true),
                    Oznacen = table.Column<bool>(type: "bit", nullable: false),
                    Vozila = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    BrojeviRacuna = table.Column<string>(type: "nvarchar(511)", maxLength: 511, nullable: true),
                    Prebivaliste = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duznici", x => x.DuznikID);
                    table.ForeignKey(
                        name: "FK_Duznici_Preduzeca_PreduzeceID",
                        column: x => x.PreduzeceID,
                        principalTable: "Preduzeca",
                        principalColumn: "PreduzeceID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Partije",
                columns: table => new
                {
                    PartijaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuznikID = table.Column<int>(type: "int", nullable: false),
                    KlijentID = table.Column<int>(type: "int", nullable: false),
                    SudID = table.Column<long>(type: "bigint", nullable: true),
                    Sud1ID = table.Column<long>(type: "bigint", nullable: true),
                    BrojPartije = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ResenjeBroj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IVb = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Pb = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MalBroj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IpvBroj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RBroj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SpojenUIBroj = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DugOd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DugDo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IznosDuga = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    AdvTarifa = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    SudskeTakse = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    TrenutniDug = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PlatioIznos = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    IznosPoPrigovoru = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ATPoPrigovoru = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    TaksaPoPrigovoru = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    DodatniAT = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    ProcenatUspjeha = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    FakturisanoProcenat = table.Column<decimal>(type: "decimal(15,2)", nullable: true),
                    PredatoDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DonetoDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrimioDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IzvrsnoDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OdlaganjeDo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IzvrsnoResenjeDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PoravnanjeDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PresudaDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrvostepenaPresudaDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DrugostepenaPresudaDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HipotekaDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PredlPokrImPredDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PredlPokrImDonDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PredlNepImPredDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PredlNepImDonDana = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Platio = table.Column<bool>(type: "bit", nullable: false),
                    Obustavljen = table.Column<bool>(type: "bit", nullable: false),
                    Storniran = table.Column<bool>(type: "bit", nullable: false),
                    Fakturisano = table.Column<bool>(type: "bit", nullable: false),
                    DostavaUredna = table.Column<bool>(type: "bit", nullable: false),
                    PoslatNaBlagajnu = table.Column<bool>(type: "bit", nullable: false),
                    PlatioOsnovniDug = table.Column<bool>(type: "bit", nullable: false),
                    Prigovor = table.Column<bool>(type: "bit", nullable: false),
                    PrigovorUsvojen = table.Column<bool>(type: "bit", nullable: false),
                    PrigovorOdbijen = table.Column<bool>(type: "bit", nullable: false),
                    PrigovorOdbacen = table.Column<bool>(type: "bit", nullable: false),
                    Popis = table.Column<bool>(type: "bit", nullable: false),
                    Procena = table.Column<bool>(type: "bit", nullable: false),
                    Prodaja = table.Column<bool>(type: "bit", nullable: false),
                    Zakljucena = table.Column<bool>(type: "bit", nullable: false),
                    Odlaganje = table.Column<bool>(type: "bit", nullable: false),
                    Odbacen = table.Column<bool>(type: "bit", nullable: false),
                    Prekinut = table.Column<bool>(type: "bit", nullable: false),
                    Odbijen = table.Column<bool>(type: "bit", nullable: false),
                    Fakturisati = table.Column<bool>(type: "bit", nullable: false),
                    FakturisatiSaPDV = table.Column<bool>(type: "bit", nullable: false),
                    NeFakturisati = table.Column<bool>(type: "bit", nullable: false),
                    IzvrsnoResenjeSuda = table.Column<bool>(type: "bit", nullable: false),
                    Poravnanje = table.Column<bool>(type: "bit", nullable: false),
                    PrvostepenaPresuda = table.Column<bool>(type: "bit", nullable: false),
                    Zalba = table.Column<bool>(type: "bit", nullable: false),
                    DrugostepenaPresuda = table.Column<bool>(type: "bit", nullable: false),
                    IzvrsenjePoPresudi = table.Column<bool>(type: "bit", nullable: false),
                    Uplatio = table.Column<bool>(type: "bit", nullable: false),
                    NemaPokretneImovine = table.Column<bool>(type: "bit", nullable: false),
                    ZakljucakNalog = table.Column<bool>(type: "bit", nullable: false),
                    ZakljucakNalogNisuPostupili = table.Column<bool>(type: "bit", nullable: false),
                    Mrtav = table.Column<bool>(type: "bit", nullable: false),
                    PredlPokrImovina = table.Column<bool>(type: "bit", nullable: false),
                    PredlNepokImovina = table.Column<bool>(type: "bit", nullable: false),
                    DodatnoFakturisati = table.Column<bool>(type: "bit", nullable: false),
                    JavnaObjava = table.Column<bool>(type: "bit", nullable: false),
                    Hipoteka = table.Column<bool>(type: "bit", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partije", x => x.PartijaID);
                    table.ForeignKey(
                        name: "FK_Partije_Duznici_DuznikID",
                        column: x => x.DuznikID,
                        principalTable: "Duznici",
                        principalColumn: "DuznikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partije_Klijenti_KlijentID",
                        column: x => x.KlijentID,
                        principalTable: "Klijenti",
                        principalColumn: "KlijentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partije_Sudovi_Sud1ID",
                        column: x => x.Sud1ID,
                        principalTable: "Sudovi",
                        principalColumn: "SudID");
                    table.ForeignKey(
                        name: "FK_Partije_Sudovi_SudID",
                        column: x => x.SudID,
                        principalTable: "Sudovi",
                        principalColumn: "SudID",
                        onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.CreateIndex(
                name: "IX_Duznici_PreduzeceID",
                table: "Duznici",
                column: "PreduzeceID");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_DuznikID",
                table: "Partije",
                column: "DuznikID");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_KlijentID",
                table: "Partije",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_Sud1ID",
                table: "Partije",
                column: "Sud1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Partije_SudID",
                table: "Partije",
                column: "SudID");

            migrationBuilder.CreateIndex(
                name: "IX_PodrazumijevaneAdvokatskeTarife_KlijentID",
                table: "PodrazumijevaneAdvokatskeTarife",
                column: "KlijentID");

            migrationBuilder.CreateIndex(
                name: "IX_PravaPristupaKlijent_KlijentID",
                table: "PravaPristupaKlijent",
                column: "KlijentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "KontniPlan");

            migrationBuilder.DropTable(
                name: "Partije");

            migrationBuilder.DropTable(
                name: "PodrazumijevaneAdvokatskeTarife");

            migrationBuilder.DropTable(
                name: "PravaPristupaKlijent");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Duznici");

            migrationBuilder.DropTable(
                name: "Sudovi");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Klijenti");

            migrationBuilder.DropTable(
                name: "Preduzeca");
        }
    }
}

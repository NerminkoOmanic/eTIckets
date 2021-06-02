using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eTicketsAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountId = table.Column<string>(maxLength: 12, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    KategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.KategorijaID);
                });

            migrationBuilder.CreateTable(
                name: "Slika",
                columns: table => new
                {
                    SlikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slika = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slika", x => x.SlikaID);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    SpolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.SpolID);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    CardId = table.Column<string>(maxLength: 17, nullable: false),
                    ControlNumber = table.Column<int>(nullable: false),
                    CardOwner = table.Column<string>(maxLength: 50, nullable: false),
                    CardValid = table.Column<string>(maxLength: 5, nullable: false),
                    AccountId = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_BankCards_Account",
                        column: x => x.AccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PodKategorija",
                columns: table => new
                {
                    PodKategorijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorijaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodKategorija", x => x.PodKategorijaID);
                    table.ForeignKey(
                        name: "FK_PodKategorija_Kategorija",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "KategorijaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<string>(maxLength: 17, nullable: false),
                    Iznos = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountId = table.Column<string>(maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Account",
                        column: x => x.AccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankTransactions_Card",
                        column: x => x.CardId,
                        principalTable: "BankCards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    KorisnickoIme = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 50, nullable: false),
                    LozinkaSalt = table.Column<string>(maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime", nullable: false),
                    UlogaID = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    SpolID = table.Column<int>(nullable: false),
                    BankAccount = table.Column<string>(maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spol",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "SpolID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Korisnik_Uloga",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdavacID = table.Column<int>(nullable: false),
                    NazivDogadjaja = table.Column<string>(maxLength: 150, nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sektor = table.Column<string>(maxLength: 15, nullable: true),
                    Red = table.Column<int>(nullable: true),
                    Sjedalo = table.Column<string>(maxLength: 30, nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    SlikaID = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    PodKategorijaID = table.Column<int>(nullable: false),
                    AdminID = table.Column<int>(nullable: true),
                    Prodano = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Admin",
                        column: x => x.AdminID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Grad",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ulaznica_PodKategorija",
                        column: x => x.PodKategorijaID,
                        principalTable: "PodKategorija",
                        principalColumn: "PodKategorijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Prodavac",
                        column: x => x.ProdavacID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ulaznica_Slika",
                        column: x => x.SlikaID,
                        principalTable: "Slika",
                        principalColumn: "SlikaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kupovine",
                columns: table => new
                {
                    TransakcijaId = table.Column<int>(nullable: false),
                    KupovinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: false),
                    TicketID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.TransakcijaId);
                    table.ForeignKey(
                        name: "FK_Transakcija_Kupac",
                        column: x => x.KupacID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transakcija_Ulaznica",
                        column: x => x.TicketID,
                        principalTable: "Ticket",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_AccountId",
                table: "BankCards",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_AccountId",
                table: "BankTransactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BankTransactions_CardId",
                table: "BankTransactions",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "CK_Email",
                table: "Korisnik",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradID",
                table: "Korisnik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "CK_KorisnickoIme",
                table: "Korisnik",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SpolID",
                table: "Korisnik",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UlogaID",
                table: "Korisnik",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_KupacID",
                table: "Kupovine",
                column: "KupacID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupovine_TicketID",
                table: "Kupovine",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_PodKategorija_KategorijaID",
                table: "PodKategorija",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_AdminID",
                table: "Ticket",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_GradID",
                table: "Ticket",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PodKategorijaID",
                table: "Ticket",
                column: "PodKategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProdavacID",
                table: "Ticket",
                column: "ProdavacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SlikaID",
                table: "Ticket",
                column: "SlikaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankTransactions");

            migrationBuilder.DropTable(
                name: "Kupovine");

            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "PodKategorija");

            migrationBuilder.DropTable(
                name: "Slika");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "Uloga");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}

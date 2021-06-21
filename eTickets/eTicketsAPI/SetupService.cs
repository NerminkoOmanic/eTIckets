using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI
{
    public class SetupService
    {   
        public void Init(IB3012Context context)
        {

            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
            }

            if (!context.Uloga.Any())
            {
                context.Uloga.Add(new Uloga()
                {
                    Naziv = "Administrator"
                });
                context.Uloga.Add(new Uloga()
                {
                    Naziv = "Klijent"
                });

                context.Drzava.Add(new Drzava()
                {
                    Naziv = "Bosna i Hercegovina"
                });

                context.Kategorija.Add(new Kategorija()
                {
                    Naziv = "Sport"
                });

                context.Kategorija.Add(new Kategorija()
                {
                    Naziv = "Music"
                });

                context.Spol.Add(new Spol()
                {
                    Naziv = "Musko"
                });
                context.Spol.Add(new Spol()
                {
                    Naziv = "Zensko"
                });

                context.BankAccounts.Add(new BankAccounts()
                {
                    AccountId = "111111111111",
                    Balance = 1500
                });
                context.BankAccounts.Add(new BankAccounts()
                {
                    AccountId = "222222222222",
                    Balance = 1500
                });

                context.BankCards.Add(new BankCards()
                {
                    CardId = "1111111111111111",
                    ControlNumber = 111,
                    CardOwner = "test",
                    CardValid = "03/22",
                    AccountId = "111111111111"
                });
                context.BankCards.Add(new BankCards()
                {
                    CardId = "2222222222222222",
                    ControlNumber = 222,
                    CardOwner = "test",
                    CardValid = "03/22",
                    AccountId = "222222222222"
                });

                context.SaveChanges();

                var entityDrzava = context.Drzava.FirstOrDefault(x => x.Naziv.Equals("Bosna i Hercegovina"));
                var entitySpol = context.Spol.FirstOrDefault(x => x.Naziv.Equals("Musko"));
                var entityAdmin = context.Uloga.FirstOrDefault(x => x.Naziv.Equals("Administrator"));
                var entityKlijent = context.Uloga.FirstOrDefault(x => x.Naziv.Equals("Klijent"));
                var entitySport = context.Kategorija.FirstOrDefault(x => x.Naziv.Equals("Sport"));
                var entityMusic = context.Kategorija.FirstOrDefault(x => x.Naziv.Equals("Music"));



                int drzavaId = entityDrzava.DrzavaId;
                int spolId = entitySpol.SpolId;
                int adminulogaId = entityAdmin.UlogaId;
                int klijentulogaId = entityKlijent.UlogaId;
                int sportId = entitySport.KategorijaId;
                int msuicId = entityMusic.KategorijaId;


                context.Grad.Add(new Grad()
                {
                    Naziv = "Mostar",
                    DrzavaId = drzavaId,
                });
                context.Grad.Add(new Grad()
                {
                    Naziv = "Sarajevo",
                    DrzavaId = drzavaId
                });

                context.PodKategorija.Add(new PodKategorija()
                {
                    Naziv = "Football",
                    KategorijaId = sportId
                });
                context.PodKategorija.Add(new PodKategorija()
                {
                    Naziv = "Basketball",
                    KategorijaId = sportId
                });
                context.PodKategorija.Add(new PodKategorija()
                {
                    Naziv = "Rock",
                    KategorijaId = msuicId
                });
                context.PodKategorija.Add(new PodKategorija()
                {
                    Naziv = "Pop",
                    KategorijaId = msuicId
                });
                context.SaveChanges();
                var entityGrad = context.Grad.FirstOrDefault(x => x.Naziv.Equals("Mostar"));
                var entityFootball = context.PodKategorija.FirstOrDefault(x => x.Naziv.Equals("Football"));
                var entityRock = context.PodKategorija.FirstOrDefault(x => x.Naziv.Equals("Rock"));


                int gradId = entityGrad.GradId;
                int footballId = entityFootball.PodKategorijaId;
                int rockId = entityRock.PodKategorijaId;

                Korisnik admin = new Korisnik()
                {
                    Ime = "admin",
                    Prezime = "admin",
                    Email = "admin@fit.ba",
                    KorisnickoIme = "admin",
                    Telefon = "(122) 223-1211",
                    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                    DatumRodjenja = DateTime.Today,
                    UlogaId = adminulogaId,
                    SpolId = spolId,
                    GradId = gradId
                };

                Korisnik user1 = new Korisnik()
                {
                    Ime = "user",
                    Prezime = "user",
                    Email = "user@fit.ba",
                    KorisnickoIme = "user",
                    Telefon = "(122) 223-1211",
                    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                    DatumRodjenja = DateTime.Today,
                    UlogaId = klijentulogaId,
                    SpolId = spolId,
                    GradId = gradId
                };
                
                Korisnik user2 = new Korisnik()
                {
                    Ime = "user2",
                    Prezime = "user2",
                    Email = "user2@fit.ba",
                    KorisnickoIme = "user2",
                    Telefon = "(122) 223-1211",
                    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                    DatumRodjenja = DateTime.Today,
                    UlogaId = klijentulogaId,
                    SpolId = spolId,
                    GradId = gradId,
                    BankAccount = "111111111111"
                };
                //context.Korisnik.Add(new Korisnik()
                //{
                //    Ime = "admin",
                //    Prezime = "admin",
                //    Email = "admin@fit.ba",
                //    KorisnickoIme = "admin",
                //    Telefon = "(122) 223-1211",
                //    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                //    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                //    DatumRodjenja = DateTime.Today,
                //    UlogaId = adminulogaId,
                //    SpolId = spolId,
                //    GradId = gradId
                //});
                //context.Korisnik.Add(new Korisnik()
                //{
                //    Ime = "user",
                //    Prezime = "user",
                //    Email = "user@fit.ba",
                //    KorisnickoIme = "user",
                //    Telefon = "(122) 223-1211",
                //    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                //    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                //    DatumRodjenja = DateTime.Today,
                //    UlogaId = klijentulogaId,
                //    SpolId = spolId,
                //    GradId = gradId
                //});
                //context.Korisnik.Add(new Korisnik()
                //{
                //    Ime = "user2",
                //    Prezime = "user2",
                //    Email = "user2@fit.ba",
                //    KorisnickoIme = "user2",
                //    Telefon = "(122) 223-1211",
                //    LozinkaHash = "1eUkf2Dokng/C1Z6opBZZyonKm4=",
                //    LozinkaSalt = "SkqFsnWs5uCbJYNyPGKWzQ==",
                //    DatumRodjenja = DateTime.Today,
                //    UlogaId = klijentulogaId,
                //    SpolId = spolId,
                //    GradId = gradId,
                //    BankAccount = "111111111111"
                //});
                context.Korisnik.AddRange(admin,user1,user2);

                Slika picFootball1 = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageFootball.jpg"))
                };
                Slika picFootball2 = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageFootball.jpg"))
                };
                Slika picFootball3 = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageFootball.jpg"))
                };

                Slika picMusic = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageMusic.jpg"))
                };

                Slika picMusic2 = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageMusic.jpg"))
                };

                Slika picMusic3 = new Slika()
                {
                    Slika1 = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "SeedImages/imageMusic.jpg"))
                };

                context.Slika.AddRange(picMusic3,picFootball1,picFootball2,picFootball3,picMusic,picMusic2);

                context.SaveChanges();

                Ticket ticket1 = new Ticket()
                {
                    NazivDogadjaja = "football1",
                    Cijena = 350,
                    GradId = gradId,
                    PodKategorijaId = footballId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    AdminId = admin.KorisnikId,
                    Sektor = "B",
                    Red = 34,
                    Sjedalo = "23",
                    SlikaId = picFootball1.SlikaId
                };
                Ticket ticket2 = new Ticket()
                {
                    NazivDogadjaja = "football2",
                    Cijena = 350,
                    GradId = gradId,
                    PodKategorijaId = footballId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    Sektor = "C",
                    Red = 34,
                    Sjedalo = "23",
                    SlikaId = picFootball2.SlikaId
                };
                Ticket ticket3 = new Ticket()
                {
                    NazivDogadjaja = "football3",
                    Cijena = 350,
                    GradId = gradId,
                    PodKategorijaId = footballId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    AdminId = admin.KorisnikId,
                    Sektor = "A",
                    Red = 3,
                    Sjedalo = "22",
                    SlikaId = picFootball3.SlikaId
                };
                Ticket ticket4 = new Ticket()
                {
                    NazivDogadjaja = "Rock1",
                    Cijena = 50,
                    GradId = gradId,
                    PodKategorijaId = rockId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    AdminId = admin.KorisnikId,
                    Sektor = "Ispred bine",
                    SlikaId = picMusic.SlikaId
                };
                Ticket ticket5 = new Ticket()
                {
                    NazivDogadjaja = "Rock2",
                    Cijena = 60,
                    GradId = gradId,
                    PodKategorijaId = footballId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    Sektor = "C",
                    Red = 34,
                    Sjedalo = "22",
                    SlikaId = picMusic2.SlikaId
                };
                Ticket ticket6 = new Ticket()
                {
                    NazivDogadjaja = "rock3",
                    Cijena = 45,
                    GradId = gradId,
                    PodKategorijaId = footballId,
                    Datum = DateTime.Now,
                    ProdavacId = user2.KorisnikId,
                    Prodano = false,
                    AdminId = admin.KorisnikId,
                    Sektor = "B",
                    Red = 34,
                    Sjedalo = "23",
                    SlikaId = picMusic3.SlikaId
                };

                context.Ticket.AddRange(ticket1,ticket2,ticket3,ticket4,ticket5,ticket6);

                context.SaveChanges();
            }
        }

    }
}

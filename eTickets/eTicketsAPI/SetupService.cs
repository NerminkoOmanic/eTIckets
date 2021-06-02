using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI
{
    public class SetupService
    {
        public async Task Init(IB3012Context context)
        {
            if (!context.Uloga.Any())
            {
                context.Database.Migrate();

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
                    Balance = 500
                });
                context.BankAccounts.Add(new BankAccounts()
                {
                    AccountId = "222222222222",
                    Balance = 500
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

                await context.SaveChangesAsync();

                var entityDrzava = await context.Drzava.FirstOrDefaultAsync(x => x.Naziv.Equals("Bosna i Hercegovina"));
                var entitySpol = await context.Spol.FirstOrDefaultAsync(x => x.Naziv.Equals("Musko"));
                var entityAdmin = await context.Uloga.FirstOrDefaultAsync(x => x.Naziv.Equals("Administrator"));
                var entityKlijent = await context.Uloga.FirstOrDefaultAsync(x => x.Naziv.Equals("Klijent"));
                var entityKategorija = await context.Kategorija.FirstOrDefaultAsync(x => x.Naziv.Equals("Sport"));


                int drzavaId = entityDrzava.DrzavaId;
                int spolId = entitySpol.SpolId;
                int adminulogaId = entityAdmin.UlogaId;
                int klijentulogaId = entityKlijent.UlogaId;
                int kategorijaId = entityKategorija.KategorijaId;

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
                    Naziv = "Fudbal",
                    KategorijaId = kategorijaId
                });
                context.PodKategorija.Add(new PodKategorija()
                {
                    Naziv = "Kosarka",
                    KategorijaId = kategorijaId
                });

                await context.SaveChangesAsync();
                var entityGrad = await context.Grad.FirstOrDefaultAsync(x => x.Naziv.Equals("Mostar"));

                int gradId = entityGrad.GradId;

                context.Korisnik.Add(new Korisnik()
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
                });
                context.Korisnik.Add(new Korisnik()
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
                });
                await context.SaveChangesAsync();
            }
        }

    }
}

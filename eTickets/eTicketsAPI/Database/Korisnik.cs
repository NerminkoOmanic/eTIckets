using System;
using System.Collections.Generic;

#nullable disable

namespace eTicketsAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KomentarKomentators = new HashSet<Komentar>();
            KomentarKomentiranis = new HashSet<Komentar>();
            TicketAdmins = new HashSet<Ticket>();
            TicketProdavacs = new HashSet<Ticket>();
            Transakcijas = new HashSet<Transakcija>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int UlogaId { get; set; }
        public int GradId { get; set; }
        public int SpolId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Komentar> KomentarKomentators { get; set; }
        public virtual ICollection<Komentar> KomentarKomentiranis { get; set; }
        public virtual ICollection<Ticket> TicketAdmins { get; set; }
        public virtual ICollection<Ticket> TicketProdavacs { get; set; }
        public virtual ICollection<Transakcija> Transakcijas { get; set; }
    }
}

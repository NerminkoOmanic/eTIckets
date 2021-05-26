using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Kupovine = new HashSet<Kupovine>();
            TicketAdmin = new HashSet<Ticket>();
            TicketProdavac = new HashSet<Ticket>();
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
        public string BankAccount { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Kupovine> Kupovine { get; set; }
        public virtual ICollection<Ticket> TicketAdmin { get; set; }
        public virtual ICollection<Ticket> TicketProdavac { get; set; }
    }
}

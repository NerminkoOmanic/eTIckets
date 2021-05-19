using System;

namespace eTickets.Model
{
    public partial class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int UlogaId { get; set; }
        public int GradId { get; set; }
        public int SpolId { get; set; }

        public virtual Grad Grad { get; set; }
        public virtual Spol Spol { get; set; }
        public virtual Uloga Uloga { get; set; }

    }
}

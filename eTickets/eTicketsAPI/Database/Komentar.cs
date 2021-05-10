using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Komentar
    {
        public int KomentarId { get; set; }
        public string Komentar1 { get; set; }
        public int KomentatorId { get; set; }
        public int KomentiraniId { get; set; }
        public DateTime Datum { get; set; }
        public int TransakcijaId { get; set; }

        public virtual Korisnik Komentator { get; set; }
        public virtual Korisnik Komentirani { get; set; }
        public virtual Transakcija Transakcija { get; set; }
    }
}

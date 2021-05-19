using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model
{
    public partial class Komentar
    {
        public int KomentarId { get; set; }
        public string KomentarString { get; set; }
        public int KomentatorId { get; set; }
        public int KomentiraniId { get; set; }
        public DateTime Datum { get; set; }
        public int TransakcijaId { get; set; }

        public virtual Korisnik Komentator { get; set; }
        public virtual Korisnik Komentirani { get; set; }
        public virtual Transakcija Transakcija { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model
{
    public partial class Transakcija
    {
        public int TransakcijaId { get; set; }
        public int KupacId { get; set; }
        public bool PotvrdaKupac { get; set; }
        public bool PotvrdaProdavac { get; set; }
        public bool UspjesnoKupac { get; set; }
        public bool UspjesnoProdavac { get; set; }
        public DateTime Datum { get; set; }
        public int TicketId { get; set; }
        public bool Uspjesna { get; set; }

        public virtual Korisnik Kupac { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}

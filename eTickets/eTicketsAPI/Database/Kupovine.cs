using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eTicketsAPI.Database
{
    public partial class Kupovine
    {
        public int KupovinaId { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public int TicketId { get; set; }
        public int TransakcijaId { get; set; }

        public virtual Korisnik Kupac { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model
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

        //nested props
        public string ProdavacString => Ticket?.Prodavac.KorisnickoIme;
        public string KupacString => Kupac?.KorisnickoIme;
        public string CijenaString => Ticket?.Cijena.ToString();

        public string NazivDogadjaja => Ticket?.NazivDogadjaja;
    }
}

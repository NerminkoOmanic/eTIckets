using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KupovineDgvExtension : Kupovine
    {
        public string ProdavacString => this.Ticket.Prodavac.KorisnickoIme;
        public string KupacString => this.Kupac.KorisnickoIme;
        public string CijenaString => this.Ticket.Cijena.ToString();

        public string NazivDogadjaja => this.Ticket.NazivDogadjaja;
    }
}

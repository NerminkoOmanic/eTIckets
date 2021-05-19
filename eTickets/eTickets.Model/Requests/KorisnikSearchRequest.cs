using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KorisnikSearchRequest
    {
        public string KorisnickoIme { get; set; }
        public int UlogaId { get; set; }
        //public string Ime { get; set; }
        //public string Prezime { get; set; }
    }
}

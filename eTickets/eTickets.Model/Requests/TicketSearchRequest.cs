using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class TicketSearchRequest
    {
        public int? KorisnikId { get; set; }
        public bool Zahtjev { get; set; }
        public bool AktivnaProdaja { get; set; }
        public bool Prodano { get; set; }
        public bool SlikaRequired { get; set; }
        public bool OrderByDatum { get; set; }
    }
}

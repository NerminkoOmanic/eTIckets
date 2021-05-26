using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class TicketSearchRequest
    {
        public bool Zahtjev { get; set; }
        public bool AktivnaProdaja { get; set; }
        public bool SlikaRequired { get; set; }
        public bool OrderByDatum { get; set; }
    }
}

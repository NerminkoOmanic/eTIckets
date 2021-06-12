using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KupovineSearchRequest
    {
        public int KorisnikId { get; set; }
        public int? PodKategorijaId { get; set; }
        public int? TicketId { get; set; }
    }
}

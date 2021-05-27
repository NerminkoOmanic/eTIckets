using System;
using System.Collections.Generic;
using System.Text;

namespace eTickets.Model.Requests
{
    public class KupovineInsertRequest
    {
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public int TicketId { get; set; }
        public int TransakcijaId { get; set; }
    }
}

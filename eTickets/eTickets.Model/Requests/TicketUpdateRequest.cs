using System;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Model.Requests
{
    public class TicketUpdateRequest
    {

        public DateTime Datum { get; set; }

        public decimal Cijena { get; set; }

        public int AdminId { get; set; }

    }
}

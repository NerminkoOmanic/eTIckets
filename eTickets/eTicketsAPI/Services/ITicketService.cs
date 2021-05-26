using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface ITicketService
    {
        IEnumerable<eTickets.Model.Ticket> Get(TicketSearchRequest search);
        eTickets.Model.Ticket GetById(int id);
    }
}

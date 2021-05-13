using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eProdaja.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface ITicketService : ICrudService<eProdaja.Model.Ticket, eProdaja.Model.TicketSearchObject,TicketInsertRequest,TicketUpdateRequest>
    {
    }
}

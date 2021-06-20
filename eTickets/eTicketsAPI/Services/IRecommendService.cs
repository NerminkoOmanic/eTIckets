using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsAPI.Services
{
    public interface IRecommendService
    {
        List<eTickets.Model.Ticket> Get();
    }
}

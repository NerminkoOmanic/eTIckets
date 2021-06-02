using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class UlogaService : BaseReadService<eTickets.Model.Uloga,Database.Uloga, object>, IUlogaService
    {
        public UlogaService(IB3012Context context, IMapper mapper) : base(context, mapper)
        {

        }

    }
}

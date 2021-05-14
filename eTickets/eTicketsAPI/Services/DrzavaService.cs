using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class DrzavaService : BaseReadService<eTickets.Model.Drzava, Database.Drzava, object>, IDrzavaService
    {
        public DrzavaService(IB3012Context context, IMapper mapper)  : base(context,mapper)
        { 
        }

    }
}

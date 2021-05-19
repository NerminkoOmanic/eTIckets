using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class SpolService : BaseReadService<eTickets.Model.Spol, Database.Spol, object>, ISpolService
    {
        public SpolService(IB3012Context context, IMapper mapper)  : base(context,mapper)
        { 
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class SlikaService :
        BaseCrudService<eTickets.Model.Slika, Database.Slika, object,SlikaInsertRequest,object>,
        ISlikaService
    {
        public SlikaService(IB3012Context context, IMapper mapper)  : base(context,mapper)
        { 
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class KategorijaService : BaseReadService<eTickets.Model.Kategorija, Database.Kategorija, object>, IKategorijaService
    {
        public KategorijaService(IB3012Context context, IMapper mapper)  : base(context,mapper)
        { 
        }

    }
}

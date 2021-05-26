using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class KategorijaService :
        BaseCrudService<eTickets.Model.Kategorija, Database.Kategorija, object,KategorijaRequest,KategorijaRequest>,
        IKategorijaService
    {
        public KategorijaService(IB3012Context context, IMapper mapper)  : base(context,mapper)
        { 
        }

    }
}

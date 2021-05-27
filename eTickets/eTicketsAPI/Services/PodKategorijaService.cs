using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class PodKategorijaService :
        BaseCrudService<eTickets.Model.PodKategorija,Database.PodKategorija, object,PodKategorijaRequest,PodKategorijaRequest>,
        IPodKategorijaService
    {

        public PodKategorijaService(IB3012Context context, IMapper mapper) : base(context,mapper)
        {
        }

        public override IEnumerable<eTickets.Model.PodKategorija> Get(object search = null)
        {
                var list = Context.PodKategorija.Include(x=>x.Kategorija).ToList();

                return _mapper.Map<List<eTickets.Model.PodKategorija>>(list);

        }
    }
}

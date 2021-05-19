using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class PodKategorijaService : BaseReadService<eTickets.Model.PodKategorija,Database.PodKategorija, object>, IPodKategorijaService
    {

        public PodKategorijaService(IB3012Context context, IMapper mapper) : base(context,mapper)
        {
        }

    }
}

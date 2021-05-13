using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class TicketService 
        : BaseCrudService<eProdaja.Model.Ticket, Database.Ticket , TicketSearchObject, TicketInsertRequest,TicketUpdateRequest>,
            ITicketService
    {
        public TicketService(IB3012Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override IEnumerable<eProdaja.Model.Ticket> Get(TicketSearchObject search = null)
        {
            var dbSet = Context.Set<Database.Ticket>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                dbSet = dbSet.Where(x => x.NazivDogadjaja.Contains(search.Naziv));
            }

            if (search.PodKategorijaId.HasValue)
            {
                dbSet = dbSet.Where(x => x.PodKategorijaId == search.PodKategorijaId);
            }

            if (search.AdminId.HasValue)
            {
                dbSet = dbSet.Where(x => x.AdminId == search.AdminId);
            }
            if (search.ProdavacId.HasValue)
            {
                dbSet = dbSet.Where(x => x.ProdavacId == search.ProdavacId);
            }

            if (search?.IncludeGrad == true)
            {
                dbSet = dbSet.Include(x=>x.Grad).Include(x=>x.Grad.Drzava);
            }

            var list = dbSet.ToList();

            return _mapper.Map<List<eProdaja.Model.Ticket>>(list);
        }
    }
}

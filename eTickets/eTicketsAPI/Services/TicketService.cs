using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class TicketService : ITicketService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;
        public TicketService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<eTickets.Model.Ticket> Get(TicketSearchRequest search = null)
        {
            var dbSet = Context.Set<Database.Ticket>().AsQueryable();

            if (search?.Zahtjev == true)
            {
                dbSet = dbSet.Where(x => x.AdminId == null);
            }

            if (search?.AktivnaProdaja == true)
            {
                dbSet = dbSet.Where(x => x.Prodano == false);
            }

            if (search?.SlikaRequired == true)
            {
                dbSet = dbSet.Include(x=>x.Slika);
            }

            if (search?.OrderByDatum == true)
            {
                dbSet = dbSet.OrderBy(x => x.Datum);
            }

            var list = dbSet.ToList();

            return _mapper.Map<List<eTickets.Model.Ticket>>(list);
        }

        public eTickets.Model.Ticket GetById(int id)
        {
            var entity = Context.Ticket.FirstOrDefault(x => x.TicketId == id);

            var dbSet = Context.Set<Database.Ticket>().AsQueryable();


            dbSet = dbSet.Include(x => x.Slika)
                .Include(x => x.Grad)
                .Include(x => x.Prodavac)
                .Include(x => x.PodKategorija)
                .Include(x => x.PodKategorija.Kategorija)
                .Include(x => x.Prodavac.Spol)
                .Include(x => x.Prodavac.Grad);


            if (entity?.AdminId != null)
            {
                dbSet = dbSet.Include(x => x.Admin)
                    .Include(x => x.Admin.Grad)
                    .Include(x => x.Admin.Spol);

            }

            entity = dbSet.FirstOrDefault(x => x.TicketId == id);

            return _mapper.Map<eTickets.Model.Ticket>(entity);
        }

        
    }
}

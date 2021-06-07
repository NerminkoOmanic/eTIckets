using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Ticket = eTickets.Model.Ticket;

namespace eTicketsAPI.Services
{
    public class KupovineService : IKupovineService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;
        public KupovineService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public IEnumerable<eTickets.Model.Kupovine> Get(KupovineSearchRequest search = null)
        {
            var dbSet = Context.Kupovine.AsQueryable();

            dbSet = dbSet.Include(x => x.Ticket)
                .Include(x => x.Kupac)
                .Include(x => x.Ticket.Prodavac);

            if (search?.KorisnikId != 0)
            {
                dbSet = dbSet.Where(x => x.KupacId == search.KorisnikId);
            }

            var list = dbSet.ToList();
            
            return _mapper.Map<List<eTickets.Model.Kupovine>>(list);
        }


        public eTickets.Model.Kupovine GetById(int id)
        {
            var entity = Context.Kupovine.Include(x => x.Kupac)
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Prodavac)
                .FirstOrDefault(x=>x.TicketId == id);

            return _mapper.Map<eTickets.Model.Kupovine>(entity);
        }

        public eTickets.Model.Kupovine Insert(KupovineInsertRequest request)
        {
            var entity = new Database.Kupovine();

            _mapper.Map(request, entity);

            Context.Kupovine.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<eTickets.Model.Kupovine>(entity);
        }

    }
}

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

           


            var dbSet = Context.Set<Database.Kupovine>().AsQueryable();

            dbSet = dbSet.Include(x => x.Ticket)
                .Include(x => x.Kupac)
                .Include(x => x.Ticket.Prodavac)
                .Include(x=>x.Ticket.Slika)
                .Include(x=>x.Ticket.Grad);

            if (search?.KorisnikId != 0)
            {
                dbSet = dbSet.Where(x => x.Kupac.KorisnikId == search.KorisnikId);
            }

            if (search?.PodKategorijaId != null)
            {
                dbSet = dbSet.Where(x => x.Ticket.PodKategorijaId == search.PodKategorijaId);
            }
            if (search?.TicketId != null)
            {
                dbSet = dbSet.Where(x => x.Ticket.TicketId == search.TicketId);
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

            var ticket = Context.Ticket.FirstOrDefault(x => x.TicketId == request.TicketId);

            if (ticket != null)
            {
                ticket.Prodano = true;
            }

            Context.Kupovine.Add(entity);
            Context.SaveChanges();

            var returnEntity = Context.Kupovine.Include(x => x.Kupac)
                                                        .Include(x => x.Ticket)
                                                        .Include(x=>x.Ticket.Prodavac)
                                                        .FirstOrDefault(x => x.KupovinaId == entity.KupovinaId);


            return _mapper.Map<eTickets.Model.Kupovine>(returnEntity);
        }

    }
}

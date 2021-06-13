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
                dbSet = dbSet.Where(x => x.Prodano == false && x.AdminId!=null);
            }

            if (search?.SlikaRequired == true)
            {
                dbSet = dbSet.Include(x=>x.Slika);
            }

            if (search?.OrderByDatum == true)
            {
                dbSet = dbSet.OrderBy(x => x.Datum);
            }
            if (search?.KorisnikId != null)
            {
                dbSet = dbSet.Where(x => x.ProdavacId == search.KorisnikId);
            }

            if (search?.Prodano == true)
            {
                dbSet = dbSet.Where(x => x.Prodano);
            }

            if (search?.PodKategorijaId != null)
            {
                dbSet = dbSet.Where(x => x.PodKategorijaId == search.PodKategorijaId);
            }
            var list = dbSet.ToList();

            return _mapper.Map<List<eTickets.Model.Ticket>>(list);
        }
        public eTickets.Model.Ticket GetById(int id)
        {
            
            var entity = PrepareEntity(id);

            return _mapper.Map<eTickets.Model.Ticket>(entity);
        }

        public eTickets.Model.Ticket Insert(TicketInsertRequest request)
        {
            var entitySlika = new Database.Slika();

            _mapper.Map(request, entitySlika);

            Context.Slika.Add(entitySlika);
            Context.SaveChanges();

            //ako mapper preslikavao null na ostale property probaj ovo
            //request.SlikaId = entitySlika.SlikaId;
            _mapper.Map(entitySlika, request);

            var entityTicket = new Database.Ticket();

            _mapper.Map(request, entityTicket);

            Context.Ticket.Add(entityTicket);
            Context.SaveChanges();

            return _mapper.Map<eTickets.Model.Ticket>(entityTicket);
        }
        public eTickets.Model.Ticket Update(int id, TicketUpdateRequest request)
        {
            var entity = PrepareEntity(id);

            request.Cijena ??= entity?.Cijena;
            if (request.Datum == DateTime.MinValue)
                request.Datum = entity.Datum;
            if (request.AdminId == null && entity?.AdminId != null)
                request.AdminId = entity.AdminId;
            

            _mapper.Map(request, entity);

            Context.SaveChanges();

            return _mapper.Map<eTickets.Model.Ticket>(entity);
        }

        public bool Remove(int id)
        {
            var entity = Context.Ticket.Find(id);
            if (entity!=null)
            {
                Context.Remove(entity);
                Context.SaveChanges();

                return true;
            }
            
            return false;
            
        }

        #region Utility

        private Database.Ticket PrepareEntity(int id)
        {
            var entity = Context.Ticket.FirstOrDefault(x => x.TicketId == id);

            var dbSet = Context.Set<Database.Ticket>().AsQueryable();


            dbSet = dbSet.Include(x => x.Slika)
                .Include(x => x.Grad)
                .Include(x => x.Prodavac)
                .Include(x => x.PodKategorija)
                .Include(x => x.PodKategorija.Kategorija);


            if (entity?.AdminId != null)
            {
                dbSet = dbSet.Include(x => x.Admin);

            }
            return dbSet.FirstOrDefault(x => x.TicketId == id);

        }

        #endregion

    }
}

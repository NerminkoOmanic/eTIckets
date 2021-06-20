using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;
using Ticket = eTickets.Model.Ticket;

namespace eTicketsAPI.Services
{
    public class RecommendService : IRecommendService
    {
        public IB3012Context Context { get; set; }
        protected readonly IMapper _mapper;

        private List<eTickets.Model.Ticket> RecommendedList { get; set; }
        private List<eTickets.Model.Ticket> ActiveList { get; set; }

            public RecommendService(IB3012Context context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public List<eTickets.Model.Ticket> Get()
        {
            eTickets.Model.Korisnik prijavljeniKorisnik = Security.BasicAuthenticationHandler.User;

            

            var dbSet = Context.Kupovine.Where(x => x.KupacId == prijavljeniKorisnik.KorisnikId)
                                                    .Select(x=>x.Ticket)
                                                    .ToList();

            RecommendedList = new List<Ticket>();
            SetActiveTickets(prijavljeniKorisnik.KorisnikId);

            if (dbSet.Any())
            {
                List<eTickets.Model.Ticket> lst = _mapper.Map<List<eTickets.Model.Ticket>>(dbSet);


                //active tickets which are same subcathegory as user's favourite goes first in list
                eTickets.Model.PodKategorija favouriteSubCathegory = GetSubCathegory(1, lst);

                


                foreach (var ticket in ActiveList)
                {
                    if (ticket.PodKategorijaId == favouriteSubCathegory.PodKategorijaId)
                    {
                        RecommendedList.Add(ticket);
                    }
                }

                RemoveDuplicates();
                //if there is second favourite subcathegory, then add those tickets to list
                eTickets.Model.PodKategorija secondfavouriteSubCathegory = GetSubCathegory(2, lst);

                if (secondfavouriteSubCathegory != null)
                {
                    foreach (var ticket in ActiveList)
                    {
                        if (ticket.PodKategorijaId == secondfavouriteSubCathegory.PodKategorijaId)
                        {
                            RecommendedList.Add(ticket);
                        }
                    }
                    RemoveDuplicates();
                }

                //depending on favourite subcathegory, take tickets which belong to same cathegory and add them to list
                foreach (var ticket in ActiveList)
                {
                    if (ticket.PodKategorija.KategorijaId == favouriteSubCathegory?.KategorijaId)
                    {
                        RecommendedList.Add(ticket);
                    }
                }
                RemoveDuplicates();

                //depending on second favourite subcathegory, take tickets which belong to same cathegory and add them to list
                if (favouriteSubCathegory?.KategorijaId != secondfavouriteSubCathegory?.KategorijaId)
                {
                    foreach (var ticket in ActiveList)
                    {
                        if (ticket.PodKategorija.KategorijaId == secondfavouriteSubCathegory?.KategorijaId)
                        {
                            RecommendedList.Add(ticket);
                        }
                    }
                    RemoveDuplicates();

                }

            }

            foreach (var ticket in ActiveList)
            {
                if (ticket.GradId == prijavljeniKorisnik.GradId)
                {
                    RecommendedList.Add(ticket);
                }
            }

            RemoveDuplicates();

            var korisnikGrad = Context.Grad.FirstOrDefault(x => x.GradId == prijavljeniKorisnik.GradId);

            foreach (var ticket in ActiveList)
            {
                if (ticket.Grad.DrzavaId == korisnikGrad?.DrzavaId)
                {
                    RecommendedList.Add(ticket);
                }
            }
            RemoveDuplicates();

            foreach (var ticket in ActiveList)
            {
                RecommendedList.Add(ticket);
            }

            return RecommendedList;

        }

        public void RemoveDuplicates()
        {
            foreach (var ticket in RecommendedList)
            {
                bool duplicate = false;
                foreach (var activeTicket in ActiveList)
                {
                    if (ticket.TicketId != activeTicket.TicketId) continue;
                    duplicate = true;
                    break;
                }

                if (duplicate)
                    ActiveList.Remove(ticket);
            }
        }
        public void SetActiveTickets(int id)
        {
            var dbSet = Context.Ticket.Include(x=>x.PodKategorija)
                                                .Include(x=>x.Grad)
                                                .Where(x => x.Prodano == false && x.AdminId != null && x.ProdavacId != id)
                                                .ToList();

            ActiveList = _mapper.Map<List<eTickets.Model.Ticket>>(dbSet);
        }

        //position --> 1 = first favourite, 2= second favourite
        public eTickets.Model.PodKategorija GetSubCathegory(int position, List<eTickets.Model.Ticket> lsTickets)
        {
            int countFirst = 0;
            int idFirst = 0;

            int countSecond = 0;
            int idSecond = 0;

            var lstSubCathegory = Context.PodKategorija.ToList();

            foreach (var subcathegory in lstSubCathegory)
            {
                int currentCount = 0;

                foreach (var ticket in lsTickets)
                {
                    if (ticket.PodKategorijaId == subcathegory.PodKategorijaId)
                        currentCount++;
                }

                if (currentCount > countSecond && currentCount > countFirst)
                {
                    idSecond = idFirst;
                    countSecond = countFirst;

                    countFirst = currentCount;
                    idFirst = subcathegory.PodKategorijaId;
                }
                if (currentCount > countSecond && currentCount <= countFirst && subcathegory.PodKategorijaId != idFirst)
                {
                    countSecond = currentCount;
                    idSecond = subcathegory.PodKategorijaId;
                }
            }
            if (position == 1 && idFirst != 0)
            {
                var entity = lstSubCathegory.FirstOrDefault(x => x.PodKategorijaId == idFirst);

                return _mapper.Map<eTickets.Model.PodKategorija>(entity);
            }
            if (position == 2 && idSecond != 0)
            {
                var entity = lstSubCathegory.FirstOrDefault(x => x.PodKategorijaId == idSecond);
                return _mapper.Map<eTickets.Model.PodKategorija>(entity);

            }
            
            return null;

            
        }
    }
}

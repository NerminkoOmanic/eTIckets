using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;

namespace eTicketsAPI.Mapping
{
    public class eProdajaProfile:Profile
    {
        public eProdajaProfile()
        {
            CreateMap<Database.Korisnik, eTickets.Model.Korisnik>();
            CreateMap<Database.Drzava, eTickets.Model.Drzava>();
            CreateMap<Database.Grad, eTickets.Model.Grad>();
            CreateMap<Database.Ticket, eTickets.Model.Ticket>();
            CreateMap<TicketInsertRequest , Database.Ticket>();
            CreateMap<TicketUpdateRequest, Database.Ticket>();
            CreateMap<KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<KorisnikUpdateRequest, Database.Korisnik>();

        }
    }
}

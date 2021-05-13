using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eProdaja.Model.Requests;

namespace eTicketsAPI.Mapping
{
    public class eProdajaProfile:Profile
    {
        public eProdajaProfile()
        {
            CreateMap<Database.Korisnik, eProdaja.Model.Korisnik>();
            CreateMap<Database.Drzava, eProdaja.Model.Drzava>();
            CreateMap<Database.Grad, eProdaja.Model.Grad>();
            CreateMap<Database.Ticket, eProdaja.Model.Ticket>();
            CreateMap<TicketInsertRequest , Database.Ticket>();
            CreateMap<TicketUpdateRequest, Database.Ticket>();
        }
    }
}

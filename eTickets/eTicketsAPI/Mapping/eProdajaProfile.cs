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
            //Mapping models
            CreateMap<Database.Korisnik, eTickets.Model.Korisnik>();
            CreateMap<Database.Drzava, eTickets.Model.Drzava>();
            CreateMap<Database.Grad, eTickets.Model.Grad>();
            CreateMap<Database.Ticket, eTickets.Model.Ticket>();
            CreateMap<Database.Kategorija, eTickets.Model.Kategorija>();
            CreateMap<Database.PodKategorija, eTickets.Model.PodKategorija>();
            CreateMap<Database.Spol, eTickets.Model.Spol>();
            CreateMap<Database.Uloga, eTickets.Model.Uloga>();
            CreateMap<Database.Komentar, eTickets.Model.Komentar>();
            CreateMap<Database.Transakcija, eTickets.Model.Transakcija>();
            CreateMap<Database.Slika, eTickets.Model.Slika>();

            //Mapping model requests
            CreateMap<TicketInsertRequest , Database.Ticket>();
            CreateMap<TicketUpdateRequest, Database.Ticket>();
            CreateMap<KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<KorisnikUpdateRequest, Database.Korisnik>();


        }
    }
}

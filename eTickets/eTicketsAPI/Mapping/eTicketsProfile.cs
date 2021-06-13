using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTickets.Model.Requests;


namespace eTicketsAPI.Mapping
{
    public class eTicketsProfile : Profile
    {
        public eTicketsProfile()
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
            CreateMap<Database.Kupovine, eTickets.Model.Kupovine>();
            CreateMap<Database.Slika, eTickets.Model.Slika>()
                .ForMember(dest=>dest.SlikaBytes,
                    opt=> opt.MapFrom(src=>src.Slika1));

            //Mapping model requests
            CreateMap<TicketInsertRequest , Database.Ticket>();
            CreateMap<TicketInsertRequest, Database.Slika>().ForMember(dest=>dest.Slika1,
                opt=> opt.MapFrom(src=>src.SlikaBytes));
            CreateMap< Database.Slika, TicketInsertRequest>().ForMember(dest=>dest.SlikaBytes,
                opt=> opt.MapFrom(src=>src.Slika1));
            CreateMap<TicketUpdateRequest, Database.Ticket>();
            CreateMap<KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<KorisnikUpdateRequest, Database.Korisnik>();
            CreateMap<KategorijaRequest, Database.Kategorija>();
            CreateMap<PodKategorijaRequest, Database.PodKategorija>();
            CreateMap<SlikaInsertRequest, Database.Slika>()
                .ForMember(dest=>dest.Slika1,
                    opt=> opt.MapFrom(src=>src.SlikaBytes));
            CreateMap<KupovineInsertRequest, Database.Kupovine>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace eTicketsAPI.Mapping
{
    public class eProdajaProfile:Profile
    {
        public eProdajaProfile()
        {
            CreateMap<Database.Korisnik, eProdaja.Model.Korisnik>();
            CreateMap<Database.Drzava, eProdaja.Model.Drzava>();
            CreateMap<Database.Grad, eProdaja.Model.Grad>();

        }
    }
}

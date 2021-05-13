using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace eTicketsAPI.Services
{
    public class KorisnikService : BaseReadService<eProdaja.Model.Korisnik, Database.Korisnik, object>, IKorisnikService
    {
        public KorisnikService(IB3012Context context, IMapper mapper) : base(context,mapper)
        {
        }
    }
}

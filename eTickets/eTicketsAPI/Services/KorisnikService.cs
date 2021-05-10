using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Database;

namespace eTicketsAPI.Services
{
    public class KorisnikService : IKorisnikService
    {
        public IB3012Context Context { get; set; }

        public KorisnikService(IB3012Context context)
        {
            Context = context;
        }
        public List<Korisnik> Get()
        {
            return Context.Korisnik.ToList();
        }
    }
}

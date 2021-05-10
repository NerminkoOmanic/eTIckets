using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Database;


namespace eTicketsAPI.Services
{
    public interface IKorisnikService
    {
        List<Korisnik> Get();
    }
}

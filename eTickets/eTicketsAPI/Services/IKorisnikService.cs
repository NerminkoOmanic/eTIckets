using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Database;
using eProdaja.Model;

namespace eTicketsAPI.Services
{
    public interface IKorisnikService : IReadService<eProdaja.Model.Korisnik, object>
    {

    }
}

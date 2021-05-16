using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model.Requests;
using eTicketsAPI.Database;


namespace eTicketsAPI.Services
{
    public interface IKorisnikService : ICrudService<eTickets.Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest,KorisnikUpdateRequest>
    {
    }
}

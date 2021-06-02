using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model.Requests;
using eTicketsAPI.Database;
using Microsoft.EntityFrameworkCore;


namespace eTicketsAPI.Services
{
    public interface IKorisnikService 
    {
        IEnumerable<eTickets.Model.Korisnik> Get(KorisnikSearchRequest search);

        eTickets.Model.Korisnik GetById(int id);

        eTickets.Model.Korisnik Insert(KorisnikInsertRequest request);

        eTickets.Model.Korisnik Update(int id, KorisnikUpdateRequest request);

        Task<eTickets.Model.Korisnik> Login(string username, string password);
        eTickets.Model.Korisnik Profil();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface IKupovineService
    {
        IEnumerable<eTickets.Model.Kupovine> Get(KupovineSearchRequest request);
        eTickets.Model.Kupovine GetById(int id);
        eTickets.Model.Kupovine Insert(KupovineInsertRequest request);
    }
}

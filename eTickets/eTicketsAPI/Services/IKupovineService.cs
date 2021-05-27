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
        IEnumerable<KupovineDgvExtension> Get();
        eTickets.Model.Kupovine GetById(int id);
        eTickets.Model.Kupovine Insert(KupovineInsertRequest request);
    }
}

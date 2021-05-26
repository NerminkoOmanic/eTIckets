using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;

namespace eTicketsAPI.Services
{
    public interface IPodKategorijaService : 
        ICrudService<eTickets.Model.PodKategorija, object, PodKategorijaRequest, PodKategorijaRequest>
    {
    }
}

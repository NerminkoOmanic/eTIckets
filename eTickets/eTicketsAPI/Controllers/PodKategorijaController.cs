using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTicketsAPI.Database;
using eTicketsAPI.Services;

namespace eTicketsAPI.Controllers
{
 
    public class PodKategorijaController :
        BaseCrudController<eTickets.Model.PodKategorija, object, PodKategorijaRequest, PodKategorijaRequest>
    {

        public PodKategorijaController(IPodKategorijaService podKategorijaService) : base(podKategorijaService)
        {
        }

    }
}

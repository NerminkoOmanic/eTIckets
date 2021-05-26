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
    public class KategorijaController :
        BaseCrudController<eTickets.Model.Kategorija, object, KategorijaRequest, KategorijaRequest>
    {

        public KategorijaController(IKategorijaService kategorijaService)
        :base(kategorijaService)
        {
        }

    }
}

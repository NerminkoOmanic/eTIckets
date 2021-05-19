using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTicketsAPI.Database;
using eTicketsAPI.Services;


namespace eTicketsAPI.Controllers
{
    public class KategorijaController : BaseReadController<eTickets.Model.Kategorija, object>
    {

        public KategorijaController(IKategorijaService kategorijaService)
        :base(kategorijaService)
        {
        }

    }
}

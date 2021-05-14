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
    [ApiController]
    [Route("[controller]")]
    public class KorisnikController : BaseReadController<eTickets.Model.Korisnik, object>
    {
        public KorisnikController(IKorisnikService korisnikService) :base(korisnikService)
        {
        }

    }
}

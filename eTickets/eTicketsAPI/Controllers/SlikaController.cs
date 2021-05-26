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
    public class SlikaController :
        BaseCrudController<eTickets.Model.Slika, object, SlikaInsertRequest, object>
    {

        public SlikaController(ISlikaService slikaService)
        :base(slikaService)
        {
        }

    }
}

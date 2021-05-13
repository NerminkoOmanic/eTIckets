using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eProdaja.Model;
using eTicketsAPI.Database;
using eTicketsAPI.Services;

namespace eTicketsAPI.Controllers
{
    public class DrzavaController : BaseReadController<eProdaja.Model.Drzava, object>
    {

        public DrzavaController(IDrzavaService drzavaService)
        :base(drzavaService)
        {
        }

    }
}

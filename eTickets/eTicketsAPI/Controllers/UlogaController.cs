using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTicketsAPI.Services;

namespace eTicketsAPI.Controllers
{
    public class UlogaController : BaseReadController<eTickets.Model.Uloga, object>
    {
        public UlogaController(IUlogaService ulogaService) : base(ulogaService)
        {
        }
    }
}

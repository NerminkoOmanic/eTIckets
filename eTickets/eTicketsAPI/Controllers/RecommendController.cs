using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTicketsAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eTicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecommendController : ControllerBase
    {
        private readonly IRecommendService _service;

        public RecommendController(IRecommendService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<eTickets.Model.Ticket> Get()
        {
            return _service.Get();
        }
    }
}

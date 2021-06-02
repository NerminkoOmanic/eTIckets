using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Model;
using eTickets.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eTicketsAPI.Database;
using eTicketsAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace eTicketsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class KupovineController : ControllerBase
    {
        private readonly IKupovineService _kupovineService;

        public KupovineController(IKupovineService kupovineService)
        {
            _kupovineService = kupovineService;
        }

        [HttpGet]
        public IEnumerable<eTickets.Model.Kupovine> Get()
        {
            return _kupovineService.Get();
        }

        [HttpGet("{id}")]
        public eTickets.Model.Kupovine GetById(int id)
        {
            return _kupovineService.GetById(id);
        }

        [HttpPost]
        public eTickets.Model.Kupovine Insert([FromBody]KupovineInsertRequest request)
        {
            return _kupovineService.Insert(request);
        }


    }
}

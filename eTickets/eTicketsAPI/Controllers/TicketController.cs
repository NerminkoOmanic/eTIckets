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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IEnumerable<eTickets.Model.Ticket> Get([FromQuery] TicketSearchRequest request)
        {
            return _ticketService.Get(request);
        }

        [HttpGet("{id}")]
        public eTickets.Model.Ticket GetById(int id)
        {
            return _ticketService.GetById(id);
        }

        //[HttpPost]
        //public eTickets.Model.Ticket Insert(KorisnikInsertRequest korisnici)
        //{
        //    return _ticketService.Insert(korisnici);
        //}

        //[HttpPut("{id}")]
        //public eTickets.Model.Ticket Update(int id, [FromBody] KorisnikUpdateRequest request)
        //{
        //    return _ticketService.Update(id, request);
        //}
       
    }
}

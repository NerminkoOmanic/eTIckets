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

namespace eTicketsAPI.Controllers
{
    public class TicketController : 
        BaseCrudController<eTickets.Model.Ticket, TicketSearchObject, TicketInsertRequest, TicketUpdateRequest>
    {
        public TicketController(ITicketService ticketService) : base(ticketService)
        {
        }


        //// PUT: api/Korisnik/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutKorisnik(int id, Korisnik korisnik)
        //{
        //    if (id != korisnik.KorisnikId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(korisnik).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KorisnikExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Korisnik
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Korisnik>> PostKorisnik(Korisnik korisnik)
        //{
        //    _context.Korisnik.Add(korisnik);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetKorisnik", new { id = korisnik.KorisnikId }, korisnik);
        //}

        //// DELETE: api/Korisnik/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Korisnik>> DeleteKorisnik(int id)
        //{
        //    var korisnik = await _context.Korisnik.FindAsync(id);
        //    if (korisnik == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Korisnik.Remove(korisnik);
        //    await _context.SaveChangesAsync();

        //    return korisnik;
        //}

        //private bool KorisnikExists(int id)
        //{
        //    return _context.Korisnik.Any(e => e.KorisnikId == id);
        //}
    }
}

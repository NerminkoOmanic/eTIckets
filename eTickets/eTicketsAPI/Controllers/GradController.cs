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
 
    public class GradController : BaseReadController<eProdaja.Model.Grad>
    {


        public GradController(IGradService gradService) : base(gradService)
        {
        }


        //// PUT: api/Grad/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGrad(int id, Grad grad)
        //{
        //    if (id != grad.GradId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(grad).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GradExists(id))
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

        //// POST: api/Grad
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Grad>> PostGrad(Grad grad)
        //{
        //    _context.Grad_1.Add(grad);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetGrad", new { id = grad.GradId }, grad);
        //}

        //// DELETE: api/Grad/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Grad>> DeleteGrad(int id)
        //{
        //    var grad = await _context.Grad_1.FindAsync(id);
        //    if (grad == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Grad_1.Remove(grad);
        //    await _context.SaveChangesAsync();

        //    return grad;
        //}

        //private bool GradExists(int id)
        //{
        //    return _context.Grad_1.Any(e => e.GradId == id);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetcorewien.Pages.Modul06;

namespace aspnetcorewien
{
    [Route("api/[controller]")]
    [ApiController]
    public class AufgabensController : ControllerBase
    {
        private readonly AufgabenContext _context;

        public AufgabensController(AufgabenContext context)
        {
            _context = context;
        }

        // GET: api/Aufgabens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aufgaben>>> GetAufgaben()
        {
            return await _context.Aufgaben.Take(10).ToListAsync();
        }

        // GET: api/Aufgabens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aufgaben>> GetAufgaben(int id)
        {
            var aufgaben = await _context.Aufgaben.FindAsync(id);

            if (aufgaben == null)
            {
                return NotFound();
            }

            return aufgaben;
        }

        // PUT: api/Aufgabens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAufgaben(int id, Aufgaben aufgaben)
        {
            if (id != aufgaben.ID)
            {
                return BadRequest();
            }

            _context.Entry(aufgaben).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AufgabenExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Aufgabens
        [HttpPost]
        public async Task<ActionResult<Aufgaben>> PostAufgaben(Aufgaben aufgaben)
        {
            _context.Aufgaben.Add(aufgaben);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAufgaben", new { id = aufgaben.ID }, aufgaben);
        }

        // DELETE: api/Aufgabens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aufgaben>> DeleteAufgaben(int id)
        {
            var aufgaben = await _context.Aufgaben.FindAsync(id);
            if (aufgaben == null)
            {
                return NotFound();
            }

            _context.Aufgaben.Remove(aufgaben);
            await _context.SaveChangesAsync();

            return aufgaben;
        }

        private bool AufgabenExists(int id)
        {
            return _context.Aufgaben.Any(e => e.ID == id);
        }
    }
}

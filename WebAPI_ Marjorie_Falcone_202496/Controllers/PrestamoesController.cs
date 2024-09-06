using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI__Marjorie_Falcone_202496.Data;
using WebAPI__Marjorie_Falcone_202496.Models;

namespace WebAPI__Marjorie_Falcone_202496.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrestamoesController : ControllerBase
    {
        private readonly BG_692024Context _context;

        public PrestamoesController(BG_692024Context context)
        {
            _context = context;
        }

        // GET: api/Prestamoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
          if (_context.Prestamos == null)
          {
              return NotFound();
          }
            return await _context.Prestamos.ToListAsync();
        }

        // GET: api/Prestamoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
          if (_context.Prestamos == null)
          {
              return NotFound();
          }
            var prestamo = await _context.Prestamos.FindAsync(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // PUT: api/Prestamoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            if (id != prestamo.IdPrestamo)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Prestamoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
          if (_context.Prestamos == null)
          {
              return Problem("Entity set 'BG_692024Context.Prestamos'  is null.");
          }
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrestamo", new { id = prestamo.IdPrestamo }, prestamo);
        }

        // DELETE: api/Prestamoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            if (_context.Prestamos == null)
            {
                return NotFound();
            }
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            _context.Prestamos.Remove(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestamoExists(int id)
        {
            return (_context.Prestamos?.Any(e => e.IdPrestamo == id)).GetValueOrDefault();
        }
    }
}

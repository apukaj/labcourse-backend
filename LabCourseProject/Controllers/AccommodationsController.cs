using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabCourseProject.Data;
using LabCourseProject.Models;

namespace LabCourseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccommodationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Accommodations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accommodation>>> GetAccommodation()
        {
            return await _context.Accommodation.ToListAsync();
        }

        // GET: api/Accommodations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accommodation>> GetAccommodation(int id)
        {
            var accommodation = await _context.Accommodation.FindAsync(id);

            if (accommodation == null)
            {
                return NotFound();
            }

            return accommodation;
        }

        // PUT: api/Accommodations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodation(int id, Accommodation accommodation)
        {
            if (id != accommodation.id)
            {
                return BadRequest();
            }

            _context.Entry(accommodation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationExists(id))
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

        // POST: api/Accommodations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Accommodation>> PostAccommodation(Accommodation accommodation)
        {
            _context.Accommodation.Add(accommodation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccommodation", new { id = accommodation.id }, accommodation);
        }

        // DELETE: api/Accommodations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Accommodation>> DeleteAccommodation(int id)
        {
            var accommodation = await _context.Accommodation.FindAsync(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            _context.Accommodation.Remove(accommodation);
            await _context.SaveChangesAsync();

            return accommodation;
        }

        private bool AccommodationExists(int id)
        {
            return _context.Accommodation.Any(e => e.id == id);
        }
    }
}

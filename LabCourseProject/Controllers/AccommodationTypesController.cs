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
    public class AccommodationTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public AccommodationTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccommodationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationType>>> GetAccommodationType()
        {
            return await _context.AccommodationType.ToListAsync();
        }

        // GET: api/AccommodationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationType>> GetAccommodationType(int id)
        {
            var accommodationType = await _context.AccommodationType.FindAsync(id);

            if (accommodationType == null)
            {
                return NotFound();
            }

            return accommodationType;
        }

        // PUT: api/AccommodationTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodationType(int id, AccommodationType accommodationType)
        {
            if (id != accommodationType.id)
            {
                return BadRequest();
            }

            _context.Entry(accommodationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationTypeExists(id))
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

        // POST: api/AccommodationTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccommodationType>> PostAccommodationType(AccommodationType accommodationType)
        {
            _context.AccommodationType.Add(accommodationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccommodationType", new { id = accommodationType.id }, accommodationType);
        }

        // DELETE: api/AccommodationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccommodationType>> DeleteAccommodationType(int id)
        {
            var accommodationType = await _context.AccommodationType.FindAsync(id);
            if (accommodationType == null)
            {
                return NotFound();
            }

            _context.AccommodationType.Remove(accommodationType);
            await _context.SaveChangesAsync();

            return accommodationType;
        }

        private bool AccommodationTypeExists(int id)
        {
            return _context.AccommodationType.Any(e => e.id == id);
        }
    }
}

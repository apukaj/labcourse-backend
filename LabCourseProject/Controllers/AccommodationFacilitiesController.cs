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
    public class AccommodationFacilitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public AccommodationFacilitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccommodationFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationFacility>>> GetAccommodationFacility()
        {
            return await _context.AccommodationFacility.ToListAsync();
        }

        // GET: api/AccommodationFacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationFacility>> GetAccommodationFacility(int id)
        {
            var accommodationFacility = await _context.AccommodationFacility.FindAsync(id);

            if (accommodationFacility == null)
            {
                return NotFound();
            }

            return accommodationFacility;
        }

        // PUT: api/AccommodationFacilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodationFacility(int id, AccommodationFacility accommodationFacility)
        {
            if (id != accommodationFacility.id)
            {
                return BadRequest();
            }

            _context.Entry(accommodationFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationFacilityExists(id))
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

        // POST: api/AccommodationFacilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccommodationFacility>> PostAccommodationFacility(AccommodationFacility accommodationFacility)
        {
            _context.AccommodationFacility.Add(accommodationFacility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccommodationFacility", new { id = accommodationFacility.id }, accommodationFacility);
        }

        // DELETE: api/AccommodationFacilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccommodationFacility>> DeleteAccommodationFacility(int id)
        {
            var accommodationFacility = await _context.AccommodationFacility.FindAsync(id);
            if (accommodationFacility == null)
            {
                return NotFound();
            }

            _context.AccommodationFacility.Remove(accommodationFacility);
            await _context.SaveChangesAsync();

            return accommodationFacility;
        }

        private bool AccommodationFacilityExists(int id)
        {
            return _context.AccommodationFacility.Any(e => e.id == id);
        }
    }
}

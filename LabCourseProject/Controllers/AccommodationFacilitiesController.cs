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

        // GET: api/AccomodationFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationFacility>>> GetAccomodationFacility()
        {
            return await _context.AccomodationFacility.ToListAsync();
        }

        // GET: api/AccomodationFacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationFacility>> GetAccomodationFacility(int id)
        {
            var accomodationFacility = await _context.AccomodationFacility.FindAsync(id);

            if (accomodationFacility == null)
            {
                return NotFound();
            }

            return accomodationFacility;
        }

        // PUT: api/AccomodationFacilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccomodationFacility(int id, AccommodationFacility accomodationFacility)
        {
            if (id != accomodationFacility.id)
            {
                return BadRequest();
            }

            _context.Entry(accomodationFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccomodationFacilityExists(id))
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

        // POST: api/AccomodationFacilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccommodationFacility>> PostAccomodationFacility(AccommodationFacility accomodationFacility)
        {
            _context.AccomodationFacility.Add(accomodationFacility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccomodationFacility", new { id = accomodationFacility.id }, accomodationFacility);
        }

        // DELETE: api/AccomodationFacilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccommodationFacility>> DeleteAccomodationFacility(int id)
        {
            var accomodationFacility = await _context.AccomodationFacility.FindAsync(id);
            if (accomodationFacility == null)
            {
                return NotFound();
            }

            _context.AccomodationFacility.Remove(accomodationFacility);
            await _context.SaveChangesAsync();

            return accomodationFacility;
        }

        private bool AccomodationFacilityExists(int id)
        {
            return _context.AccomodationFacility.Any(e => e.id == id);
        }
    }
}

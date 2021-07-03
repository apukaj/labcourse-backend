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
    public class AccommodationReservationsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccommodationReservationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AccommodationReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccommodationReservation>>> GetAccommodationReservation()
        {
            return await _context.AccommodationReservation.ToListAsync();
        }

        // GET: api/AccommodationReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccommodationReservation>> GetAccommodationReservation(int id)
        {
            var accommodationReservation = await _context.AccommodationReservation.FindAsync(id);

            if (accommodationReservation == null)
            {
                return NotFound();
            }

            return accommodationReservation;
        }

        // PUT: api/AccommodationReservations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccommodationReservation(int id, AccommodationReservation accommodationReservation)
        {
            if (id != accommodationReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(accommodationReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationReservationExists(id))
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

        // POST: api/AccommodationReservations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccommodationReservation>> PostAccommodationReservation(AccommodationReservation accommodationReservation)
        {
            _context.AccommodationReservation.Add(accommodationReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccommodationReservation", new { id = accommodationReservation.Id }, accommodationReservation);
        }

        // DELETE: api/AccommodationReservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccommodationReservation>> DeleteAccommodationReservation(int id)
        {
            var accommodationReservation = await _context.AccommodationReservation.FindAsync(id);
            if (accommodationReservation == null)
            {
                return NotFound();
            }

            _context.AccommodationReservation.Remove(accommodationReservation);
            await _context.SaveChangesAsync();

            return accommodationReservation;
        }

        private bool AccommodationReservationExists(int id)
        {
            return _context.AccommodationReservation.Any(e => e.Id == id);
        }
    }
}

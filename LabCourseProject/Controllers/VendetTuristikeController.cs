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
    public class VendetTuristikeController : ControllerBase
    {
        private readonly DataContext _context;

        public VendetTuristikeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/VendetTuristikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendetTuristike>>> GetVendetTuristike()
        {
            return await _context.VendetTuristike.ToListAsync();
        }

        // GET: api/VendetTuristikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendetTuristike>> GetVendetTuristike(int id)
        {
            var vendetTuristike = await _context.VendetTuristike.FindAsync(id);

            if (vendetTuristike == null)
            {
                return NotFound();
            }

            return vendetTuristike;
        }

        // PUT: api/VendetTuristikes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendetTuristike(int id, VendetTuristike vendetTuristike)
        {
            if (id != vendetTuristike.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendetTuristike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendetTuristikeExists(id))
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

        // POST: api/VendetTuristikes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VendetTuristike>> PostVendetTuristike(VendetTuristike vendetTuristike)
        {
            _context.VendetTuristike.Add(vendetTuristike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendetTuristike", new { id = vendetTuristike.Id }, vendetTuristike);
        }

        // DELETE: api/VendetTuristikes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VendetTuristike>> DeleteVendetTuristike(int id)
        {
            var vendetTuristike = await _context.VendetTuristike.FindAsync(id);
            if (vendetTuristike == null)
            {
                return NotFound();
            }

            _context.VendetTuristike.Remove(vendetTuristike);
            await _context.SaveChangesAsync();

            return vendetTuristike;
        }

        private bool VendetTuristikeExists(int id)
        {
            return _context.VendetTuristike.Any(e => e.Id == id);
        }
    }
}

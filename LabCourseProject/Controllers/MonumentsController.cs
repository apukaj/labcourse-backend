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
    public class MonumentsController : ControllerBase
    {
        private readonly DataContext _context;

        public MonumentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Monuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Monument>>> GetMonument()
        {
            return await _context.Monument.ToListAsync();
        }

        // GET: api/Monuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Monument>> GetMonument(int id)
        {
            var monument = await _context.Monument.FindAsync(id);

            if (monument == null)
            {
                return NotFound();
            }

            return monument;
        }

        // PUT: api/Monuments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonument(int id, Monument monument)
        {
            if (id != monument.Id)
            {
                return BadRequest();
            }

            _context.Entry(monument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonumentExists(id))
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

        // POST: api/Monuments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Monument>> PostMonument(Monument monument)
        {
            _context.Monument.Add(monument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonument", new { id = monument.Id }, monument);
        }

        // DELETE: api/Monuments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Monument>> DeleteMonument(int id)
        {
            var monument = await _context.Monument.FindAsync(id);
            if (monument == null)
            {
                return NotFound();
            }

            _context.Monument.Remove(monument);
            await _context.SaveChangesAsync();

            return monument;
        }

        private bool MonumentExists(int id)
        {
            return _context.Monument.Any(e => e.Id == id);
        }
    }
}

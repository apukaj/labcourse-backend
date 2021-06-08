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
    public class CavesController : ControllerBase
    {
        private readonly DataContext _context;

        public CavesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Caves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cave>>> GetCave()
        {
            return await _context.Cave.ToListAsync();
        }

        // GET: api/Caves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cave>> GetCave(int id)
        {
            var cave = await _context.Cave.FindAsync(id);

            if (cave == null)
            {
                return NotFound();
            }

            return cave;
        }

        // PUT: api/Caves/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCave(int id, Cave cave)
        {
            if (id != cave.Id)
            {
                return BadRequest();
            }

            _context.Entry(cave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaveExists(id))
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

        // POST: api/Caves
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cave>> PostCave(Cave cave)
        {
            _context.Cave.Add(cave);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCave", new { id = cave.Id }, cave);
        }

        // DELETE: api/Caves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cave>> DeleteCave(int id)
        {
            var cave = await _context.Cave.FindAsync(id);
            if (cave == null)
            {
                return NotFound();
            }

            _context.Cave.Remove(cave);
            await _context.SaveChangesAsync();

            return cave;
        }

        private bool CaveExists(int id)
        {
            return _context.Cave.Any(e => e.Id == id);
        }
    }
}

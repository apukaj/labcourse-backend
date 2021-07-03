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
    public class ShoppingFacilitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ShoppingFacilitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingFacility>>> GetShoppingFacility()
        {
            return await _context.ShoppingFacility.ToListAsync();
        }

        // GET: api/ShoppingFacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingFacility>> GetShoppingFacility(int id)
        {
            var shoppingFacility = await _context.ShoppingFacility.FindAsync(id);

            if (shoppingFacility == null)
            {
                return NotFound();
            }

            return shoppingFacility;
        }

        // PUT: api/ShoppingFacilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingFacility(int id, ShoppingFacility shoppingFacility)
        {
            if (id != shoppingFacility.id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingFacilityExists(id))
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

        // POST: api/ShoppingFacilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShoppingFacility>> PostShoppingFacility(ShoppingFacility shoppingFacility)
        {
            _context.ShoppingFacility.Add(shoppingFacility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingFacility", new { id = shoppingFacility.id }, shoppingFacility);
        }

        // DELETE: api/ShoppingFacilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingFacility>> DeleteShoppingFacility(int id)
        {
            var shoppingFacility = await _context.ShoppingFacility.FindAsync(id);
            if (shoppingFacility == null)
            {
                return NotFound();
            }

            _context.ShoppingFacility.Remove(shoppingFacility);
            await _context.SaveChangesAsync();

            return shoppingFacility;
        }

        private bool ShoppingFacilityExists(int id)
        {
            return _context.ShoppingFacility.Any(e => e.id == id);
        }
    }
}

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
    public class RestaurantTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantType>>> GetRestaurantType()
        {
            return await _context.RestaurantType.ToListAsync();
        }

        // GET: api/RestaurantTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantType>> GetRestaurantType(int id)
        {
            var restaurantType = await _context.RestaurantType.FindAsync(id);

            if (restaurantType == null)
            {
                return NotFound();
            }

            return restaurantType;
        }

        // PUT: api/RestaurantTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurantType(int id, RestaurantType restaurantType)
        {
            if (id != restaurantType.id)
            {
                return BadRequest();
            }

            _context.Entry(restaurantType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantTypeExists(id))
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

        // POST: api/RestaurantTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RestaurantType>> PostRestaurantType(RestaurantType restaurantType)
        {
            _context.RestaurantType.Add(restaurantType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurantType", new { id = restaurantType.id }, restaurantType);
        }

        // DELETE: api/RestaurantTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RestaurantType>> DeleteRestaurantType(int id)
        {
            var restaurantType = await _context.RestaurantType.FindAsync(id);
            if (restaurantType == null)
            {
                return NotFound();
            }

            _context.RestaurantType.Remove(restaurantType);
            await _context.SaveChangesAsync();

            return restaurantType;
        }

        private bool RestaurantTypeExists(int id)
        {
            return _context.RestaurantType.Any(e => e.id == id);
        }
    }
}

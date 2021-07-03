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
    public class ShoppingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ShoppingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Shoppings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shopping>>> GetShopping()
        {
            return await _context.Shopping.ToListAsync();
        }

        // GET: api/Shoppings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shopping>> GetShopping(int id)
        {
            var shopping = await _context.Shopping.FindAsync(id);

            if (shopping == null)
            {
                return NotFound();
            }

            return shopping;
        }

        // PUT: api/Shoppings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopping(int id, Shopping shopping)
        {
            if (id != shopping.id)
            {
                return BadRequest();
            }

            _context.Entry(shopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingExists(id))
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

        // POST: api/Shoppings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shopping>> PostShopping(Shopping shopping)
        {
            _context.Shopping.Add(shopping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopping", new { id = shopping.id }, shopping);
        }

        // DELETE: api/Shoppings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shopping>> DeleteShopping(int id)
        {
            var shopping = await _context.Shopping.FindAsync(id);
            if (shopping == null)
            {
                return NotFound();
            }

            _context.Shopping.Remove(shopping);
            await _context.SaveChangesAsync();

            return shopping;
        }

        private bool ShoppingExists(int id)
        {
            return _context.Shopping.Any(e => e.id == id);
        }
    }
}

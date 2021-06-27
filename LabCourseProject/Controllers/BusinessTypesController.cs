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
    public class BusinessTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public BusinessTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BusinessTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessType>>> GetBusinessType()
        {
            return await _context.BusinessType.ToListAsync();
        }

        // GET: api/BusinessTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessType>> GetBusinessType(int id)
        {
            var businessType = await _context.BusinessType.FindAsync(id);

            if (businessType == null)
            {
                return NotFound();
            }

            return businessType;
        }

        // PUT: api/BusinessTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessType(int id, BusinessType businessType)
        {
            if (id != businessType.id)
            {
                return BadRequest();
            }

            _context.Entry(businessType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessTypeExists(id))
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

        // POST: api/BusinessTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessType>> PostBusinessType(BusinessType businessType)
        {
            _context.BusinessType.Add(businessType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessType", new { id = businessType.id }, businessType);
        }

        // DELETE: api/BusinessTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessType>> DeleteBusinessType(int id)
        {
            var businessType = await _context.BusinessType.FindAsync(id);
            if (businessType == null)
            {
                return NotFound();
            }

            _context.BusinessType.Remove(businessType);
            await _context.SaveChangesAsync();

            return businessType;
        }

        private bool BusinessTypeExists(int id)
        {
            return _context.BusinessType.Any(e => e.id == id);
        }
    }
}

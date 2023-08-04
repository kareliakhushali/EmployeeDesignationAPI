using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeInfo.Models;

namespace EmployeeInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtraController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public ExtraController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Extra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Extra>>> GetExtra()
        {
            return await _context.Extra.ToListAsync();
        }

        // GET: api/Extra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Extra>> GetExtra(int id)
        {
            var extra = await _context.Extra.FindAsync(id);

            if (extra == null)
            {
                return NotFound();
            }

            return extra;
        }

        // PUT: api/Extra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExtra(int id, Extra extra)
        {
            if (id != extra.Id)
            {
                return BadRequest();
            }

            _context.Entry(extra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(id))
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

        // POST: api/Extra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Extra>> PostExtra(Extra extra)
        {
            _context.Extra.Add(extra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExtra", new { id = extra.Id }, extra);
        }

        // DELETE: api/Extra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExtra(int id)
        {
            var extra = await _context.Extra.FindAsync(id);
            if (extra == null)
            {
                return NotFound();
            }

            _context.Extra.Remove(extra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExtraExists(int id)
        {
            return _context.Extra.Any(e => e.Id == id);
        }
    }
}

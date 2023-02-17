using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupProject.Models;

namespace GroupProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchesController : ControllerBase
    {
        private readonly MerchContext _context;

        public MerchesController(MerchContext context)
        {
            _context = context;
        }

        // GET: api/Merches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merch>>> GetMerchy()
        {
            return await _context.Merchy.ToListAsync();
        }

        // GET: api/Merches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merch>> GetMerch(string id)
        {
            var merch = await _context.Merchy.FindAsync(id);

            if (merch == null)
            {
                return NotFound();
            }

            return merch;
        }

        // PUT: api/Merches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerch(string id, Merch merch)
        {
            if (id != merch.itemName)
            {
                return BadRequest();
            }

            _context.Entry(merch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchExists(id))
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

        // POST: api/Merches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merch>> PostMerch(Merch merch)
        {
            _context.Merchy.Add(merch);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MerchExists(merch.itemName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMerch", new { id = merch.itemName }, merch);
        }

        // DELETE: api/Merches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerch(string id)
        {
            var merch = await _context.Merchy.FindAsync(id);
            if (merch == null)
            {
                return NotFound();
            }

            _context.Merchy.Remove(merch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchExists(string id)
        {
            return _context.Merchy.Any(e => e.itemName == id);
        }
    }
}

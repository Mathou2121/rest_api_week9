using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactInterventionApi.Models;

namespace FactIntervention.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly FactInterventionContext _context;

        public ColumnsController(FactInterventionContext context)
        {
            _context = context;
        }

        // // GET: api/Columns/all
        // [HttpGet("all")]
        // public async Task<ActionResult<IEnumerable<Column>>> GetColumns()
        // {
        //     return await _context.columns.ToListAsync();
        // }

        // GET: api/Columns/(id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> GetColumn(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // PUT: api/Columns/5    //Put Request must be the full body, not just the update
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColumn(long id, Column column)
        {
            if (id != column.Id)
            {
                return BadRequest();
            }

            _context.Entry(column).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
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

        // POST: api/Columns
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Column>> PostColumn(Column column)
        // {
        //     _context.columns.Add(column);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetColumn", new { id = column.Id }, column);
        // }

        // // DELETE: api/Columns/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Column>> DeleteColumn(long id)
        // {
        //     var column = await _context.Columns.FindAsync(id);
        //     if (column == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Columns.Remove(column);
        //     await _context.SaveChangesAsync();

        //     return column;
        // }

        private bool ColumnExists(long id)
        {
            return _context.columns.Any(e => e.Id == id);
        }
    }
}

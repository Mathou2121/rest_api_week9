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
    public class InterventionsController : ControllerBase
    {
        private readonly FactInterventionContext _context;

        public InterventionsController(FactInterventionContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetIntervention()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> GetIntervention(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetPendingRequest()
        {
           var pending = await _context.interventions.Where(p => p.status.Equals("Pending") || p.startdate.Equals(null)).ToListAsync();
            return pending;
        }

        // PUT: api/Interventions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPut("{id}/inprogress")]
        public async Task<ActionResult<Intervention>> PutInterventionToInProgress([FromRoute] long id)
        {
            var intervention_current = await this._context.interventions.FindAsync(id);
            if (intervention_current == null)
            {
                return NotFound();
            }
            else
            {
                intervention_current.status = "InProgress";
                intervention_current.startdate = System.DateTime.Now;
            }
            this._context.interventions.Update(intervention_current);
            await this._context.SaveChangesAsync();

            return Content("The status of the elevator ID: " + intervention_current.id +
            " has been changed to: " + intervention_current.status + ". The start date was updated to : " + intervention_current.startdate);
        }

        [HttpPut("{id}/completed")]
        public async Task<ActionResult<Intervention>> PutInterventionToCompleted([FromRoute] long id)
        {
            var intervention_current = await this._context.interventions.FindAsync(id);
            if (intervention_current == null)
            {
                return NotFound();
            }
            else
            {
                intervention_current.status = "Completed";
                intervention_current.enddate = System.DateTime.Now;
            }
            this._context.interventions.Update(intervention_current);
            await this._context.SaveChangesAsync();

            return Content("The status of the elevator ID: " + intervention_current.id +
            " has been changed to: " + intervention_current.status + ". The end date was updated to : " + intervention_current.startdate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervention1(long id, Intervention intervention)
        {
            if (id != intervention.id)
            {
                return BadRequest();
            }

            _context.Entry(intervention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
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

        // POST: api/Interventions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Intervention>> PostIntervention(Intervention intervention)
        {
            _context.interventions.Add(intervention);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervention", new { id = intervention.id }, intervention);
        }

        // DELETE: api/Interventions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Intervention>> DeleteIntervention(long id)
        {
            var intervention = await _context.interventions.FindAsync(id);
            if (intervention == null)
            {
                return NotFound();
            }

            _context.interventions.Remove(intervention);
            await _context.SaveChangesAsync();

            return intervention;
        }

        private bool InterventionExists(long id)
        {
            return _context.interventions.Any(e => e.id == id);
        }
    }
}

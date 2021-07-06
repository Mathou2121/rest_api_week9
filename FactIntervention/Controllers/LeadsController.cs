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
    public class LeadsController : ControllerBase
    {
        private readonly FactInterventionContext _context;

        public LeadsController(FactInterventionContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        // {
        //     return await _context.leads.ToListAsync();
        // }
        // GET: api/Leads/5
        // [HttpGet]
        // public IEnumerable<Lead> GetLead(long id)
        // {   
        //     var Mydate = System.DateTime.Now.AddDays(-30);
        //     var customersList = _context.customers.ToList();
        //     var leadEmail = _context.leads.ToList();
        //     foreach (var customer in customersList) {
        //     Console.WriteLine(customer.email_of_the_company_contact);
        //     if (customer.email_of_the_company_contact == leadEmail.Find())
        //     {
                
            
        //     IQueryable<Lead> Leads = 
        //      from lead in _context.leads
        //     where lead.created_at  >= Mydate
        //     select lead;
        //     return Leads.ToList(); }
        //     }
        //     else
        //     {
        //         return NoContent()
        //     }
        // }

        // PUT: api/Leads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutLead(long id, Lead lead)
        // {
        //     if (id != lead.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(lead).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!LeadExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Leads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        // [HttpPost]
        // public async Task<ActionResult<Lead>> PostLead(Lead lead)
        // {
        //     _context.leads.Add(lead);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        // }

        // // DELETE: api/Leads/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<Lead>> DeleteLead(long id)
        // {
        //     var lead = await _context.leads.FindAsync(id);
        //     if (lead == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.leads.Remove(lead);
        //     await _context.SaveChangesAsync();

        //     return lead;
        // }

        private bool LeadExists(long id)
        {
            return _context.leads.Any(e => e.Id == id);
        }
    }
}

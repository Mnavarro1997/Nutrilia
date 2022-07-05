using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nutrilia.DataBase;
using Nutrilia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrilia.Controllers
{
    public class PlansController : Controller
    {
        private readonly EcommerceDb _context;

        public PlansController(EcommerceDb context)
        {
            _context = context;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plans>>> GetPlans()
        {
            return await _context.Plans.ToListAsync();
        }

        // GET: api/Plans/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Plans>> GetPlan(int id)
        {
            var plan = await _context.Plans.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plans plan)
        {
            if (id != plan.Id_Plan)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plans>> PostPlan(Plans plans)
        {
            _context.Plans.Add(plans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plans.Id_Plan }, plans);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanExists(int id)
        {
            return _context.Plans.Any(e => e.Id_Plan == id);
        }
    }
}

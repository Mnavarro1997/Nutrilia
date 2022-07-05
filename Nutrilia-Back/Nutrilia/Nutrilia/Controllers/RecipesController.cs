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
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
         private readonly EcommerceDb _context;

        public RecipesController(EcommerceDb context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipes>>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipes>> GetRecipes(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipes(int id, Recipes recipes)
        {
            if (id != recipes.Id_Recipe)
            {
                return BadRequest();
            }

            _context.Entry(recipes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(id))
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

        // POST: api/Cart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recipes>> PostRecipes(Recipes recipes)
        {
            _context.Recipes.Add(recipes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipe", new { id = recipes.Id_Recipe}, recipes);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipes(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.Id_Recipe== id);
        }
    }
    }


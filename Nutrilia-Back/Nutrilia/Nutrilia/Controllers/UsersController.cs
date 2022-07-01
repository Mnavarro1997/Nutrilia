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
    public class UsersController : ControllerBase
    {
        private readonly EcommerceDb _context;

        public UsersController(EcommerceDb context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsuarios()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsuario(int id)
        {
            var usuario = await _context.Users.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Users user)
        {
            if (id != user.Id_User)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsuario(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = users.Id_User }, users);
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<ActionResult<Users>> Login(Users users)
        {
            var user = _context.Users.Where(user => user.Email.Equals(users.Email)).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Email incorrecto");
            }
            if (user.Password != users.Password)
            {
                return BadRequest("Contraseña incorrecta");
            }
            return Ok(user);

        }


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Users.Any(e => e.Id_User == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using APIExamen3.Data;
using APIExamen3.Models;
using Microsoft.EntityFrameworkCore;

namespace APIExamen3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CancionesController:ControllerBase
    {
        private readonly CancionesContext _context;

        public CancionesController(CancionesContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancion>>> GetCanciones()
        {
            return await _context.Canciones.ToListAsync();
        }

        //GET ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cancion>> GetCanciones(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }
            return cancion;
        }

        //ACTUALIZAR
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanciones(int id, Cancion cancion)
        {
            if (id != cancion.Id)
            {
                return BadRequest();
            }
            _context.Entry(cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Canciones.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else { throw; }
            }
            return NoContent();
        }

        //Insertar
        [HttpPost]
        public async Task<ActionResult<Cancion>> PostCancion (Cancion cancion) 
        {
                _context.Canciones.Add(cancion);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCanciones), new { id = cancion.Id }, cancion);         
        }

        //Eliminar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancion(int id)
        {
            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion == null)
            {
                return NotFound();
            }

            _context.Canciones.Remove(cancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

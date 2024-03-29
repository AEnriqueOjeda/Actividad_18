﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad_18.Server.Contexto;
using Actividad_18.Shared.Models;

namespace Actividad_18.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaContexto _context;

        public LibrosController(BibliotecaContexto context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            var libros = await _context.Libros.Include(l => l.Prestamo).ToListAsync();
            return libros;
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libros>> GetLibros(int id)
        {
            var libros = await _context.Libros.Include(l => l.Prestamo).FirstOrDefaultAsync(l => l.Id == id);

            if (libros == null)
            {
                return NotFound();
            }

            return libros;
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibros(int id, Libros libros)
        {
            if (id != libros.Id)
            {
                return BadRequest();
            }

            _context.Entry(libros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrosExists(id))
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

        // POST: api/Libros
        [HttpPost]
        public async Task<ActionResult<Libros>> PostLibros(Libros libros)
        {
            if (libros.PrestamosId == 0 || libros.PrestamosId == null)
            {
                libros.PrestamosId = null;
            }

            _context.Libros.Add(libros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibros", new { id = libros.Id }, libros);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibros(int id)
        {
            var libros = await _context.Libros.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libros);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibrosExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }

        // GET: api/Libros/Prestamos/5
        [HttpGet("Prestamos/{prestamosId}")]
        public async Task<ActionResult<IEnumerable<Libros>>> GetLibrosByPrestamosId(int prestamosId)
        {
            var libros = await _context.Libros.Include(l => l.Prestamo).Where(l => l.PrestamosId == prestamosId).ToListAsync();

            if (libros == null || libros.Count == 0)
            {
                return NotFound();
            }

            return libros;
        }
    }
}

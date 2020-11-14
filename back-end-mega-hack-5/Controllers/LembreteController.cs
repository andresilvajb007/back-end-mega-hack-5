using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end_mega_hack_5.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end_mega_hack_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembreteController : ControllerBase
    {

        private readonly Context _context;

        public LembreteController(Context context)
        {
            _context = context;
        }

        // GET: api/TipoBoleto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.Lembrete.ToListAsync();

            if(lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        // GET: api/TipoBoleto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var lembrete = await _context.Lembrete.FindAsync(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            return Ok(lembrete);
        }

        // POST: api/TipoBoleto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lembrete lembrete)
        {            
            await _context.Lembrete.AddAsync(lembrete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get",new { id = lembrete.Id });
        }

        // PUT: api/TipoBoleto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Lembrete lembrete)
        {

            var obj = await _context.Lembrete.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }


            lembrete.Id = id;
            _context.Entry(lembrete).State = EntityState.Modified;
            await _context.SaveChangesAsync();
    

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lembrete = await _context.Lembrete.FindAsync(id);

            if (lembrete == null)
            {
                return NotFound();
            }

            _context.Lembrete.Remove(lembrete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

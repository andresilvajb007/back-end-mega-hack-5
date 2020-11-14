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
    public class TipoBoletoController : ControllerBase
    {

        private readonly Context _context;

        public TipoBoletoController(Context context)
        {
            _context = context;
        }

        // GET: api/TipoBoleto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.TipoBoleto.ToListAsync();

            if(lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista);
        }

        // GET: api/TipoBoleto/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var tipoBoleto = await _context.TipoBoleto.FindAsync(id);

            if (tipoBoleto == null)
            {
                return NotFound();
            }

            return Ok(tipoBoleto);
        }

        // POST: api/TipoBoleto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string descricao)
        {
            var tipoBoleto = new TipoBoleto { Descricao = descricao };
            await _context.TipoBoleto.AddAsync(tipoBoleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get",tipoBoleto.Id);
        }

        // PUT: api/TipoBoleto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string descricao)
        {

            var tipoBoleto = await _context.TipoBoleto.FindAsync(id);

            if (tipoBoleto == null)
            {
                return NotFound();
            }


             tipoBoleto = new TipoBoleto { Id = id, Descricao = descricao };
            _context.Entry(tipoBoleto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
    

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoBoleto = await _context.TipoBoleto.FindAsync(id);

            if (tipoBoleto == null)
            {
                return NotFound();
            }

            _context.TipoBoleto.Remove(tipoBoleto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

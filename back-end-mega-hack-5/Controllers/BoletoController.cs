using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end_mega_hack_5.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end_mega_hack_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoletoController : ControllerBase
    {

        private readonly Context _context;

        public BoletoController(Context context)
        {
            _context = context;
        }

        // GET: api/TipoBoleto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.Boleto.Include(x=>x.TipoBoleto).ToListAsync();

            if(lista.Count == 0)
            {
                return NotFound();
            }

            return Ok(lista.Select(x=>
            new
            {
                x.Id,
                x.TipoBoleto.Descricao,
                x.Valor,
                DataVencimento = x.DataVencimento.HasValue ? x.DataVencimento.Value.ToShortDateString(): string.Empty,
                DataPagamento = x.DataPagamento.HasValue ? x.DataPagamento.Value.ToShortDateString() : string.Empty,
                Status = x.EnumStatusBoleto.ToString()
            }));
        }

        // GET: api/TipoBoleto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var boleto = await _context.Boleto.Include(x => x.TipoBoleto).Where(x => x.Id == id).FirstAsync();

            if (boleto == null)
            {
                return NotFound();
            }

            return Ok(
            new
            {
                boleto.Id,
                boleto.TipoBoleto.Descricao,
                boleto.Valor,
                DataVencimento = boleto.DataVencimento.HasValue ? boleto.DataVencimento.Value.ToShortDateString() : string.Empty,
                DataPagamento = boleto.DataPagamento.HasValue ? boleto.DataPagamento.Value.ToShortDateString() : string.Empty,
                Status = boleto.EnumStatusBoleto.ToString()
            });
        }
        

        // POST: api/TipoBoleto
        [HttpPost("Pagamento")]
        public async Task<IActionResult> Post([FromBody] Boleto boleto)
        {            
            await _context.Boleto.AddAsync(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get",new { id = boleto.Id });
        }
        
     
    }
}

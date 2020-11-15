using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end_mega_hack_5.Entidades;
using back_end_mega_hack_5.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end_mega_hack_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {

        private readonly Context _context;

        public ClienteController(Context context)
        {
            _context = context;
        }


        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromQuery] string usuario,[FromQuery] string senha)
        {
            // Recupera o usuário
            var user = await _context.Cliente
                .Where(x => x.Usuario == usuario && x.Senha == senha)
                                                  .FirstOrDefaultAsync();

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user.Usuario, "Empreendedor");

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }

        // GET: api/TipoBoleto
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _context.Cliente.Include(x=>x.ContaCorrente).ToListAsync();

            if(lista.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(lista.Select(x => new { x.Id, x.Nome, x.CPF, x.ContaCorrente.Saldo }));
        }

        // GET: api/TipoBoleto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Find(int id)
        {
            var cliente = await _context.Cliente.Include(x => x.ContaCorrente).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(new { cliente.Id, cliente.Nome, cliente.CPF, cliente.ContaCorrente.Saldo});
        }

        // POST: api/TipoBoleto
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {            
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get",new { id = cliente.Id });
        }

        // PUT: api/TipoBoleto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente cliente)
        {

            var obj = await _context.Cliente.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            obj.CPF = cliente.CPF;
            obj.Nome = cliente.Nome;
            obj.Usuario = cliente.Usuario;
            obj.Senha = cliente.Senha;

            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
    

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

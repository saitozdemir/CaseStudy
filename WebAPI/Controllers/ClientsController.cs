using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebbApi.Controllers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientsController(ClientContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = await _context.Clients.ToListAsync();
            client.Reverse();
            return Ok(client);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clients client)
        {
            if (client == null || client.Id != 0 || String.IsNullOrEmpty(client.Name))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            await _context.Clients.AddAsync(client);
            _context.SaveChanges();

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Clients client)
        {
            if (client == null || client.Id == 0 || String.IsNullOrEmpty(client.Name))
            {
                return BadRequest();
            }

            var oldClient = _context.Clients.SingleOrDefault(p => p.Id == client.Id);
            if (oldClient == null)
            {
                return NotFound();
            }
            _context.Entry(oldClient).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _context.Clients.SingleOrDefault(p => p.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return Ok(client);
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripeApiProto.Data;
using StripeApiProto.Models;

namespace StripeApiProto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly StripeDbContext _context;
        public ClientsController(StripeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return Created("", client);
        }
    }
}

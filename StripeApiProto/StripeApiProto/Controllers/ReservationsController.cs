using Microsoft.AspNetCore.Mvc;
using StripeApiProto.Data;
using StripeApiProto.Models;

namespace StripeApiProto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly StripeDbContext _context;

        public ReservationsController(StripeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Reservation>> GetById(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAReservation(Reservation res)
        {
            await _context.Reservations.AddAsync(res);
            await _context.SaveChangesAsync();
            return Created("", res);
        }
    }
}

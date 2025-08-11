//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using StripeApiProto.Data;
//using StripeApiProto.Models;

//namespace StripeApiProto.Controllers
//{
//    public class ReservationsMVCController : Controller
//    {
//        private readonly StripeDbContext _context;

//        public ReservationsMVCController(StripeDbContext context)
//        {
//            _context = context;
//        }

//        // GET: ReservationsMVC
//        public async Task<IActionResult> Index()
//        {
//            var stripeDbContext = _context.Reservations.Include(r => r.Client);
//            return View(await stripeDbContext.ToListAsync());
//        }

//        // GET: ReservationsMVC/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservation = await _context.Reservations
//                .Include(r => r.Client)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (reservation == null)
//            {
//                return NotFound();
//            }

//            return View(reservation);
//        }

//        // GET: ReservationsMVC/Create
//        public IActionResult Create()
//        {
//            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
//            return View();
//        }

//        // POST: ReservationsMVC/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Title,Description,CoverImage,IsConfirmed,ClientId,TotalPrice")] Reservation reservation)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(reservation);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
//            return View(reservation);
//        }

//        // GET: ReservationsMVC/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservation = await _context.Reservations.FindAsync(id);
//            if (reservation == null)
//            {
//                return NotFound();
//            }
//            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
//            return View(reservation);
//        }

//        // POST: ReservationsMVC/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CoverImage,IsConfirmed,ClientId,TotalPrice")] Reservation reservation)
//        {
//            if (id != reservation.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(reservation);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ReservationExists(reservation.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", reservation.ClientId);
//            return View(reservation);
//        }

//        // GET: ReservationsMVC/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reservation = await _context.Reservations
//                .Include(r => r.Client)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (reservation == null)
//            {
//                return NotFound();
//            }

//            return View(reservation);
//        }

//        // POST: ReservationsMVC/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var reservation = await _context.Reservations.FindAsync(id);
//            if (reservation != null)
//            {
//                _context.Reservations.Remove(reservation);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ReservationExists(int id)
//        {
//            return _context.Reservations.Any(e => e.Id == id);
//        }
//    }
//}

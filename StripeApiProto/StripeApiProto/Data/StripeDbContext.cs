using Microsoft.EntityFrameworkCore;
using StripeApiProto.Models;

namespace StripeApiProto.Data;

public class StripeDbContext : DbContext
{
    public StripeDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}

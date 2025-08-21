using Microsoft.EntityFrameworkCore;
using Taksi.Entities;

namespace Taksi.Data
{
    public class TaksiDbContext : DbContext
    {
        public TaksiDbContext(DbContextOptions<TaksiDbContext> options) : base(options) { }

        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Coupon> Coupons { get; set; } = null!;
        public DbSet<Bonus> Bonuses { get; set; } = null!;
        public DbSet<SupportRequest> SupportRequests { get; set; } = null!;
    }
}

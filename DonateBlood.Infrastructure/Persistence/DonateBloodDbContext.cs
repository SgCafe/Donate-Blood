using DonateBlood.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonateBlood.Infrastructure.Persistence
{
    public class DonateBloodDbContext : DbContext
    {

        public DonateBloodDbContext(DbContextOptions<DonateBloodDbContext> options)
            : base()
        {

        }

        public DbSet<Donations> Donations { get; set; }
        public DbSet<Donors> Donors { get; set; }
        public DbSet<DonationStock>

    }
}

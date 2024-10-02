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

        public DbSet<Donors> Donors { get; set; }
        public DbSet<Adreess> Adreess { get; set; }
        public DbSet<Donations> Donations { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<StockDonation> StockDonation { get; set; }
        public DbSet<DonorDonation> DonorsDonation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<DonorDonation>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(d => d.Donor)
                        .WithMany(dd => dd.DonorDonation)
                        .HasForeignKey(fk => fk.DonorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(d => d.Donation)
                        .WithMany(dd => dd.DonorDonation)
                        .HasForeignKey(fk => fk.Donation)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}

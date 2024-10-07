using DonateBlood.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonateBlood.Infrastructure.Persistence
{
    public class DonateBloodDbContext : DbContext
    {

        public DonateBloodDbContext(DbContextOptions<DonateBloodDbContext> options)
            : base(options)
        {

        }

        public DbSet<Donors> Donors { get; set; }
        //certo, vou remodelar, valeu
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
                        .HasForeignKey(fk => fk.DonationId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<StockDonation>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(s => s.Stock)
                        .WithMany(sd => sd.StockDonation)
                        .HasForeignKey(fk => fk.StockId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(d => d.Donation)
                        .WithMany(sd => sd.StockDonation)
                        .HasForeignKey(fk => fk.DonationId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Donors>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasMany(d => d.Donations)
                        .WithOne(dd => dd.Donor)
                        .HasForeignKey(fk => fk.DonorId)
                        .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(d => d.Adreess)
                        .WithOne(a => a.Donor)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Donations>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(s => s.Stock)
                        .WithMany(d => d.Donations)
                        .HasForeignKey(fk => fk.StockId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}

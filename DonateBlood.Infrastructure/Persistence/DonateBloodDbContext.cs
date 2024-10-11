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
        public DbSet<Donations> Donations { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<StockDonation> StockDonation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Donors>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.OwnsOne(o => o.Address, sa =>
                    {
                        sa.Property(p => p.Street).HasColumnName("Street");
                        sa.Property(p => p.City).HasColumnName("City");
                        sa.Property(p => p.State).HasColumnName("State");
                        sa.Property(p => p.PostalCode).HasColumnName("PostalCode");
                    });

                    e.Property(d => d.BloodType)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                    e.Property(d => d.FactorRh)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                    e.HasMany(d => d.Donations)
                        .WithOne(dd => dd.Donor)
                        .HasForeignKey(fk => fk.DonorId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder
               .Entity<Donations>(e =>
               {
                   e.HasKey(e => e.Id);

                   e.HasOne(s => s.Donor)
                       .WithMany(d => d.Donations)
                       .HasForeignKey(x => x.DonorId)
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

            base.OnModelCreating(builder);
        }
    }
}

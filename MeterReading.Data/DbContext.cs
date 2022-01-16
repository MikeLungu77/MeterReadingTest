using MeterReading.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading.Data
{
    public class SqlDbContext : DbContext, ISqlDbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDto> AccountDto { get; set; }
        public virtual DbSet<MeterReadingDto> MeterReadingDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDto>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<MeterReadingDto>(entity =>
            {
                entity.HasOne(d => d.Account)
                    .WithMany(p => p.MeterReadings)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}



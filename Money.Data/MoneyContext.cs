using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Money.Data.Models;
using System.Data.Entity;

namespace Money.Data
{
    public class MoneyDbContext: DbContext
    {
        public MoneyDbContext(): base("MoneyDbConnectionString")
        {
        }

        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Money");

            modelBuilder.Entity<Mortgage>()
                .HasKey<int>(m => m.MortgageId)
                .ToTable("Mortgages", "Money");

            modelBuilder.Entity<Transaction>()
                .HasKey<int>(t => t.TransactionId)
                .ToTable("Transactions", "Money");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("Money");
        }
    }
}

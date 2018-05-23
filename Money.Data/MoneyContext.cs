using Money.Data.Models;
using Money.Data.Models.Configuration;
using System.Data.Entity;

namespace Money.Data
{
    public class MoneyDbContext: DbContext
    {
        public MoneyDbContext(): base("HomeManagement")
        {
        }

        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Money");

            modelBuilder.Configurations.Add(new MortgageEntityConfiguration());
            modelBuilder.Configurations.Add(new TransactionEntityConfiguration());
        }
    }
}

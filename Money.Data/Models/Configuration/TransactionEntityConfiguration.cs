using System.Data.Entity.ModelConfiguration;

namespace Money.Data.Models.Configuration
{
    public class TransactionEntityConfiguration: EntityTypeConfiguration<Transaction>
    {
        public TransactionEntityConfiguration()
        {
            HasKey<int>(t => t.Id);

            Property(t => t.Amount)
                .HasColumnType("Money");
        }
    }
}

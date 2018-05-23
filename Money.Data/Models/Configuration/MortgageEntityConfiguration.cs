using System.Data.Entity.ModelConfiguration;

namespace Money.Data.Models.Configuration
{
    public class MortgageEntityConfiguration: EntityTypeConfiguration<Mortgage>
    {
        public MortgageEntityConfiguration()
        {
            HasKey<int>(m => m.Id);

            Property(p => p.LoanAmount)
                .HasColumnType("Money");
        }
    }
}

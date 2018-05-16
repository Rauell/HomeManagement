using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Data
{
    [Table("Mortgages", Schema="Money")]
    public class Mortgage
    {
        [Key]
        public int MortgageId { get; set; }
        public int NumberOfMonths { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }

        public static Mortgage DefaultMortgage
        {
            get
            {
                return GetMortgage();
            }
        }

        public static Mortgage GetMortgage(decimal loanAmount = 300000, int numberOfMonths = 360, DateTime? startDate = null)
        {
            return new Mortgage(loanAmount, numberOfMonths, startDate);
        }


        public Mortgage(decimal loanAmount = 300000, int numberOfMonths = 360, DateTime? startDate = null)
        {
            LoanAmount = loanAmount;
            NumberOfMonths = numberOfMonths;
            StartDate = startDate ?? DateTime.Now;
        }

    }
}

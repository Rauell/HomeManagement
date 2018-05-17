using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Data.Models
{
    public class Mortgage
    {
        public int MortgageId { get; set; }
        public int NumberOfMonths { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

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

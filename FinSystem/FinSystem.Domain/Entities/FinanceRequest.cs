using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Domain.Entities
{
    public class FinanceRequest
    {
        public int Id { get; set; }
        public int RequestNumber { get; set; }
        public double PaymentAmount { get; set; }
        public int PaymentPeriod { get; set; } // Months (1–12)
        public double TotalProfit { get; set; }
        public bool RequestStatus { get; set; } // true = Active, false = Inactive
    }
}

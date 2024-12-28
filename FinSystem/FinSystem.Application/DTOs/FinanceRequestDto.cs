using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Application.DTOs
{
    public class FinanceRequestDto
    {
        public int RequestNumber { get; set; }
        public double PaymentAmount { get; set; }
        public int PaymentPeriod { get; set; }
        public double TotalProfit { get; set; }
        public bool RequestStatus { get; set; }
    }
}

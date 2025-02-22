﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Domain.Filters
{
    public class FinanceRequestFilterDto
    {
        public int? RequestNumber { get; set; }
        public bool? RequestStatus { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}

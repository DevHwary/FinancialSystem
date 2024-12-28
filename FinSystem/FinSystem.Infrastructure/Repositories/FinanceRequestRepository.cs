using FinSystem.Domain.Entities;
using FinSystem.Domain.Filters;
using FinSystem.Domain.Interfaces;
using FinSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinSystem.Infrastructure.Repositories
{
    public class FinanceRequestRepository : IFinanceRequestRepository
    {
        private readonly AppDbContext _context;

        public FinanceRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<FinanceRequest> Data, int TotalCount)> GetAllWithPaginationAsync(FinanceRequestFilterDto filter)
        {
            var query = _context.FinanceRequests.AsQueryable();

            if (filter.RequestNumber.HasValue)
            {
                query = query.Where(fr => fr.RequestNumber == filter.RequestNumber.Value);
            }

            if (filter.RequestStatus.HasValue)
            {
                query = query.Where(fr => fr.RequestStatus == filter.RequestStatus.Value);
            }

            var totalCount = await query.CountAsync();

            var data = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return (data, totalCount);
        }
    }
}

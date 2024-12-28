using FinSystem.Domain.Entities;
using FinSystem.Domain.Filters;

namespace FinSystem.Domain.Interfaces
{
    public interface IFinanceRequestRepository
    {
        Task<(IEnumerable<FinanceRequest> Data, int TotalCount)> GetAllWithPaginationAsync(FinanceRequestFilterDto filter);
    }
}

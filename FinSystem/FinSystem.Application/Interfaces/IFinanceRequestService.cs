using FinSystem.Application.DTOs;
using FinSystem.Domain.Entities;
using FinSystem.Domain.Filters;

namespace FinSystem.Application.Interfaces
{
    public interface IFinanceRequestService
    {
        Task<PagedResponse<FinanceRequestDto>> GetFinanceRequestsAsync(FinanceRequestFilterDto filterDto);
    }
}

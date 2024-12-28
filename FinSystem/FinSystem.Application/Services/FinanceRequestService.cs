using FinSystem.Application.DTOs;
using FinSystem.Application.Interfaces;
using FinSystem.Domain.Filters;
using FinSystem.Domain.Interfaces;

namespace FinSystem.Application.Services
{
    public class FinanceRequestService : IFinanceRequestService
    {
        private readonly IFinanceRequestRepository _repository;

        public FinanceRequestService(IFinanceRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<FinanceRequestDto>> GetFinanceRequestsAsync(FinanceRequestFilterDto filterDto)
        {
            var filter = new FinanceRequestFilterDto
            {
                RequestNumber = filterDto.RequestNumber,
                RequestStatus = filterDto.RequestStatus,
                PageNumber = filterDto.PageNumber,
                PageSize = filterDto.PageSize
            };

            var result = await _repository.GetAllWithPaginationAsync(filter);

            return new PagedResponse<FinanceRequestDto>
            {
                CurrentPage = filter.PageNumber,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)filter.PageSize),
                TotalRows = result.TotalCount,
                Data = result.Data.Select(fr => new FinanceRequestDto
                {
                    RequestNumber = fr.RequestNumber,
                    PaymentAmount = fr.PaymentAmount,
                    PaymentPeriod = fr.PaymentPeriod,
                    TotalProfit = fr.TotalProfit,
                    RequestStatus = fr.RequestStatus
                }).ToList()
            };
        }
    }
}

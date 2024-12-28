using FinSystem.Application.Interfaces;
using FinSystem.Domain.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/Finance")]
    [Authorize]
    public class FinanceController : ControllerBase
    {
        private readonly IFinanceRequestService _service;

        public FinanceController(IFinanceRequestService service)
        {
            _service = service;
        }


        [HttpPost("filter")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFinanceRequests(FinanceRequestFilterDto filterDto)
        {
            if (filterDto == null)
            {
                return BadRequest(new { Message = "The request body is empty or invalid." });
            }

            var pagedResponse = await _service.GetFinanceRequestsAsync(filterDto);

            return Ok(new
            {
                CurrentPage = pagedResponse.CurrentPage,
                TotalPages = pagedResponse.TotalPages,
                TotalRows = pagedResponse.TotalRows,
                Data = pagedResponse.Data
            });
        }
    }
}

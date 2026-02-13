using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartApprovalSystem.API.Response;
using SmartApprovalSystem.Application.DTOs.Requests;
using SmartApprovalSystem.Application.Interfaces;

namespace SmartApprovalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Employee")]

    public class RequestController(IRequestService _requestService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestDto createRequestDto)
        {
            var result = await _requestService.CreateRequestAsync(createRequestDto);
            return Ok(new SuccessResponse<int>(result));
        }
    }
}

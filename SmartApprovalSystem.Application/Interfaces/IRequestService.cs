using SmartApprovalSystem.Application.DTOs.Requests;
namespace SmartApprovalSystem.Application.Interfaces
{
    public interface IRequestService
    {
       public Task<int> CreateRequestAsync( CreateRequestDto createRequestDto);
    }
}

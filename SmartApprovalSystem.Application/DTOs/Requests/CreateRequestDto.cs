using SmartApprovalSystem.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace SmartApprovalSystem.Application.DTOs.Requests
{
    public class CreateRequestDto
    {
        [Required , MaxLength(200 , ErrorMessage ="MaxLength is 200 Pleas Follow This Validation")]
        public string Title { get; set; } = default!;

        [Required , MaxLength(400 , ErrorMessage ="MaxLength is 400 Pleas Follow This Validation")]
        public string Description { get; set; } = default!;

        public RequestType RequestType { get; set; } = default!;
        public ApprovalStatus RequestStatus { get; set; }
    }
}

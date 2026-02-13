using SmartApprovalSystem.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.Models
{
    public class ApprovalStep
    {
        public int Id { get; set; }
        public int StepOrder { get; set; }
        public string ApproverUserId { get; set; } = default!;
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
        public string? ActionByUserId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? RejectionReason { get; set; }
        //Navigation property
        public int RequestId { get; set; }
        public Request Request { get; set; } = default!;
    }

}

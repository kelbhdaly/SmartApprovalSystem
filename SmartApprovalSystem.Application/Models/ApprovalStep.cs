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
        public int ID { get; set; }
        public int StepOrder { get; set; }
        public string ApproverUserId { get; set; } = default!;
        public RequestStatus RequestStatus { get; set; }

        // Navigation property
        public int RequestId { get; set; }

    }
}

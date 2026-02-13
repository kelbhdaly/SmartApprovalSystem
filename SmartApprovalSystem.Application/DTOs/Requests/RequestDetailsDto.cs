using SmartApprovalSystem.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.DTOs.Requests
{
    public class RequestDetailsDto
    {
        //RequestId
        public int RequestId { get; set; }
        //        Title
        public string Title { get; set; } = default!;

        //        Description
        public string Description { get; set; } = default!;

        //RequestType
        public RequestType RequestType { get; set; }
        //Status
        public Status Status { get; set; }

        //CreatedAt
        public DateTime DateTime { get; set; }
    }
}

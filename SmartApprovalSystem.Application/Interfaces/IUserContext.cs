using SmartApprovalSystem.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.Interfaces
{
    public interface IUserContext
    {
        public string UserId { get; }
        ApproverRole ApproverRole { get; }

    }
}

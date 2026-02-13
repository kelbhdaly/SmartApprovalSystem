using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.Interfaces
{
    public interface IUserService
    {
        public Task<bool> Exists(string userId);
    }
}

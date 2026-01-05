using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; } = default!;

        // Navigation property
        public string ManagerUserId { get; set; } = default!;

    }
}

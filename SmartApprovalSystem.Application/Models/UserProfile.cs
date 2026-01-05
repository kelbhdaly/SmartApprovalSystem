using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartApprovalSystem.Application.Models
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string FullName { get; set; } = default!;

        // Navigation property 
        public string UserId { get; set; }
        public int DepartmentId { get; set; }
        
    }
}

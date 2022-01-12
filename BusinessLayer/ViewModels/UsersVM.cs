using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class UsersVM
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; } = (int)Roles.Student;
        public int StatusId { get; set; } = (int)Statuses.Active;
        public string StatusName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ViewModels
{
    public class RolesVM
    {
        public int RoleId { get; set; } = (int)Roles.Student;
        public string Name { get; set; } = string.Empty;
        public int StatusId { get; set; } = (int)Statuses.Active;
    }
}

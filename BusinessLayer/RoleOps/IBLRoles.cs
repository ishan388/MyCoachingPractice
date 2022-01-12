using BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.RoleOps
{
    public interface IBLRoles
    {
        public Task<Response<RolesVM>> Post(RolesVM role);
        public Task<Response<RolesVM>> Put(RolesVM role);
        public Task<Response<RolesVM>> Delete(int roleId);
        public Task<Response<RolesVM>> Get();
        public Task<Response<RolesVM>> Get(int roleId);

        public bool IsAdmin(int roleId);
        public bool IsTeacher(int roleId);
        public bool IsPrincipal(int roleId);
        public bool IsStudent(int roleId);
    }
}

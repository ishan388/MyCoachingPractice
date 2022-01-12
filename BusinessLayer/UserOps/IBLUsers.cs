using BusinessLayer.ViewModels;
using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.UserOps
{
    public interface IBLUsers
    {
        public Task<Response<UsersVM>> Post(UsersVM user);
        public Task<Response<UsersVM>> Put(UsersVM user);
        public Task<Response<UsersVM>> Delete(int userId);
        public Task<Response<UsersVM>> Get();
        public Task<Response<UsersVM>> Get(int userId);
        public Task<Response<UsersVM>> Login(UsersVM user);
        public Task<Response<UsersVM>> Logout();
        public Task<Response<UsersVM>> ForgetPassword(string email);
        public Task<Response<UsersVM>> ResetPassword(int userId, string newPassword);
    }
}

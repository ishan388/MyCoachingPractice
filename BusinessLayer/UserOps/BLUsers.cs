using BusinessLayer.ViewModels;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.UserOps
{
    public class BLUsers : IBLUsers
    {
        public async Task<Response<UsersVM>> Delete(int userId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Users.Remove(GetUser(userId).Result);
                    await context.SaveChangesAsync();
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "User removed Successfully"
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "User can't be deleted"
                };
            }
        }

        public async Task<Response<UsersVM>> ForgetPassword(string email)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User CheckUser = await context.Users
                        .Where(e => e.Email.ToLower() == email.ToLower())
                        .SingleOrDefaultAsync();

                    if (CheckUser != null)
                    {
                        return new Response<UsersVM>()
                        {
                            IsSuccess = true,
                            Message = "User Found Successfully",
                            Data = new UsersVM()
                            {
                                UserId = CheckUser.UserId,
                                FullName = CheckUser.FullName,
                            }
                        };
                    }
                    else
                    {
                        return new Response<UsersVM>()
                        {
                            IsSuccess = false,
                            Message = "Invalid User"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "Please enter the valid inputs"
                };
            }
        }

        public async Task<Response<UsersVM>> Get()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "Users list fetched successfully",
                        DataList = await context.Users
                        .Select(e => new UsersVM()
                        {
                            UserId = e.UserId,
                            Email = e.Email,
                            FullName = e.FullName,
                            Password = e.Password,
                            RoleId = e.RoleId,
                            StatusId = e.StatusId,
                            StatusName = e.Status.Name,
                            RoleName = e.Role.Name
                        })
                        .ToListAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "Users don't exist: "
                };
            }
        }

        public async Task<Response<UsersVM>> Get(int userId)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "User data fetched successfully",
                        Data = await context.Users
                                .Where(e => e.UserId == userId)
                                .Select(e => new UsersVM()
                                {
                                    UserId = e.UserId,
                                    Email = e.Email,
                                    FullName = e.FullName,
                                    Password = e.Password,
                                    RoleId = e.RoleId,
                                    StatusId = e.StatusId,
                                    StatusName = e.Status.Name,
                                    RoleName = e.Role.Name
                                })
                                .SingleOrDefaultAsync()
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "User doesn't exist"
                };
            }
        }

        public async Task<User> GetUser(int userId)
        {
            using (AppDbContext context = new AppDbContext())
            {
                return await context.Users
                        .Where(e => e.UserId == userId)
                        .SingleOrDefaultAsync();
            }
        }

        public async Task<Response<UsersVM>> Login(UsersVM user)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User CheckUser = await context.Users.Where(e => e.RoleId == user.RoleId
                    && e.Email.ToLower() == user.Email.ToLower()
                    && e.Password == user.Password
                    && e.StatusId == (int)Statuses.Active).SingleOrDefaultAsync();

                    if (CheckUser != null)
                    {
                        return new Response<UsersVM>()
                        {
                            IsSuccess = true,
                            Message = "User Login Successfully",
                            Data = new UsersVM()
                            {
                                UserId = CheckUser.UserId,
                                Email = CheckUser.Email,
                                FullName = CheckUser.FullName,
                                StatusId = CheckUser.StatusId,
                                RoleId = CheckUser.RoleId
                            }
                        };
                    }
                    else
                    {
                        return new Response<UsersVM>()
                        {
                            IsSuccess = false,
                            Message = "The entered username and password is not valid for selected Role type"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "Please enter the valid inputs"
                };
            }
        }

        public async Task<Response<UsersVM>> Logout()
        {
            return new Response<UsersVM>()
            {
                IsSuccess = true,
                Message = "User Logged out successfully"
            };
        }

        public async Task<Response<UsersVM>> Post(UsersVM user)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    context.Users.Add(new User()
                    {
                        Email = user.Email,
                        FullName = user.FullName,
                        Password = user.Password,
                        RoleId = user.RoleId,
                        StatusId = user.StatusId,
                    });
                    await context.SaveChangesAsync();
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "User Added Successfully",
                        Data = user
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "User Can't be added"
                };
            }
        }

        public async Task<Response<UsersVM>> Put(UsersVM user)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User ctxUser = GetUser(user.UserId).Result;
                    ctxUser.RoleId = user.RoleId;
                    ctxUser.StatusId = user.StatusId;
                    ctxUser.FullName = user.FullName;
                    ctxUser.Email = user.Email;
                    ctxUser.Password = user.Password;
                    await context.SaveChangesAsync();
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "User Updated Successfully",
                        Data = user
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "User can't be Updated"
                };
            }
        }

        public async Task<Response<UsersVM>> ResetPassword(int userId, string newPassword)
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    User ctxUser = GetUser(userId).Result;
                    ctxUser.Password = newPassword;
                    await context.SaveChangesAsync();
                    return new Response<UsersVM>()
                    {
                        IsSuccess = true,
                        Message = "Password Reset Successfully"
                    };
                }
            }
            catch (Exception)
            {
                return new Response<UsersVM>()
                {
                    IsSuccess = false,
                    Message = "Password can't be reset"
                };
            }
        }
    }
}